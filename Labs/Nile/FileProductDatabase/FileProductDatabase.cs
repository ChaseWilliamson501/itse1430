using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nile;
using Nile.Stores;

namespace FileProductDatabase
{
    public class FileProductDatabase : ProductDatabase
    {
        public FileProductDatabase( string filename )
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));
            if (filename == "")
                throw new ArgumentException("Filename cannot be empty.", nameof(filename));

            _filename = filename;
        }

        private readonly string _filename;
        protected override Product AddCore( Product product )
        {
            
            var products = GetAllCore().ToList();

            //Find the largest Id and increment by 1
            if (products.Any())
                product.Id = products.Max(x => x.Id) + 1;
            else
                product.Id = 1;

            //Add to list
            products.Add(product);

            //Save the products
            SaveProducts(products);

            return product;
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            if (File.Exists(_filename))
            {
                //Read all at once
                foreach (var line in File.ReadAllLines(_filename))
                {
                    var product = LoadProduct(line);
                    if (product != null)
                        yield return product;
                };
            };
        }

        protected override Product GetCore( int id )
        {
            if (!File.Exists(_filename))
                return null;

            
            using (StreamReader reader = File.OpenText(_filename))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var product = LoadProduct(line);
                    if (product.Id == id)
                        return product;
                };

                return null;
            };
        }

        private Product LoadProduct( string line )
        {
            if (String.IsNullOrEmpty(line))
                return null;

            var fields = line.Split(',');
            if (fields.Length != 6)
                return null;

            return new Product {
                Id = Int32.Parse(fields[0]),
                Name = fields[1],
                Description = fields[2],
                Price = Decimal.Parse(fields[3]),
                IsDiscontinued = Boolean.Parse(fields[4]),
                
            };
        }

        protected override void RemoveCore( int id )
        {
            var products = GetAllCore().ToList();

            var product = products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                products.Remove(product);
                SaveProducts(products);
            };
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            var products = GetAllCore().ToList();

            //Replace old product with new one
            var current = products.FirstOrDefault(x => x.Id == existing.Id);
            if (current != null)
            {
                products.Remove(existing);
                newItem.Id = current.Id;
                products.Add(newItem);

                SaveProducts(products);
            };

            return newItem;
        }

        private string SaveProduct( Product product )
        {
            return String.Join(",", product.Id, product.Name, product.Description, product.Price, product.IsDiscontinued);
        }

        private void SaveProducts( IEnumerable<Product> products )
        {
            
            var lines = from product in products
                        select SaveProduct(product);

            File.WriteAllLines(_filename, lines);
        }
    }
}
