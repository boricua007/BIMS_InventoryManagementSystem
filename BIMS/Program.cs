using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}

public class Program
{
    public static List<Product> inventory = new List<Product>
    {
        new Product { Name = "Apple", Price = 0.5m, Quantity = 100 },
        new Product { Name = "Banana", Price = 0.3m, Quantity = 150 },
        new Product { Name = "Orange", Price = 0.8m, Quantity = 80 }
    };
    public static void Main( string[ ] args )
    {
        Console.WriteLine( "=== BORICUA'S INVENTORY MANAGEMENT SYSTEM ===" );
        Console.WriteLine( "Welcome! BIMS helps you manage your product inventory.\n" );

        bool keepRunning = true;
        while ( keepRunning )
        {
            Console.WriteLine( "Please choose an option:" );
            Console.WriteLine( "1. View Products" );
            Console.WriteLine( "2. Add Product" );
            Console.WriteLine( "3. Update Product" );
            Console.WriteLine( "4. Delete Product" );
            Console.WriteLine( "5. Exit" );

            int choice = int.Parse( Console.ReadLine( ) );

            switch ( choice )
            {
                case 1:
                    ViewProducts( );
                    break;
                case 2:
                    AddProduct( );
                    break;
                case 3:
                    UpdateProduct( );
                    break;
                case 4:
                    DeleteProduct( );
                    break;
                case 5:
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine( "Invalid choice, please try again." );
                    break;
            }
        }
    }


    private static void ViewProducts( )
    {
        Console.WriteLine( "\n=== INVENTORY REPORT ===" );

        // Check if inventory is empty
        if ( inventory == null || inventory.Count == 0 )
        {
            Console.WriteLine( "No products available in the inventory." );
            return;
        }
        Console.WriteLine( "Product Name\tPrice\tQuantity" );
        Console.WriteLine( "-------------------------------------" );

        foreach ( var product in inventory )
        {
            Console.WriteLine( $"{product.Name}\t{product.Price:C}\t{product.Quantity}" );
        }
        Console.WriteLine( "-------------------------------------" );
        Console.WriteLine( $"Total Products: {inventory.Count}" );
        Console.WriteLine( "Total Value: " + CalculateTotalValue( ).ToString( "C" ) );
        Console.WriteLine( " " );
    }

    private static decimal CalculateTotalValue( )
    {
        decimal total = 0;
        foreach ( var product in inventory )
        {
            total += product.Price * product.Quantity;
        }
        return total;
    }

    private static void AddProduct( )
    {
        Console.WriteLine( "\n=== ADD NEW PRODUCT ===" );

        Console.WriteLine( "Enter product name:" );
        string name = Console.ReadLine( );

        if ( string.IsNullOrEmpty( name ) )
        {
            Console.WriteLine( "ERROR: Product name cannot be empty!" );
            Console.WriteLine( " " );
            return;
        }

        // Check if product already exists
        bool productExists = false;
        for ( int i = 0; i < inventory.Count; i++ )
        {
            if ( inventory[ i ].Name.ToLower( ) == name.ToLower( ) )
            {
                productExists = true;
                break;
            }
        }

        if ( productExists )
        {
            Console.WriteLine( "Product already exists. Please choose a different name." );
            return;
        }

        // Get product price
        Console.WriteLine( "Enter product price:" );
        decimal price = decimal.Parse( Console.ReadLine( ) );

        if ( price <= 0 )
        {
            Console.WriteLine( "ERROR: Price must be greater than zero!" );
            return;
        }

        // Get product quantity
        Console.WriteLine( "Enter product quantity:" );
        int quantity = int.Parse( Console.ReadLine( ) );

        inventory.Add( new Product { Name = name, Price = price, Quantity = quantity } );
        Console.WriteLine( "Product added successfully!" );
    }

    private static void UpdateProduct( )
    {
        Console.WriteLine( "\n=== UPDATE PRODUCT ===" );

        if ( inventory == null || inventory.Count == 0 )
        {
            Console.WriteLine( "No products available to update." );
            return;
        }

        // Get product name to update
        Console.WriteLine( "Enter product name to update:" );
        string name = Console.ReadLine( );

        // Check if name is empty
        if ( string.IsNullOrEmpty( name ) )
        {
            Console.WriteLine( "ERROR: Product name cannot be empty!" );
            return;
        }


        // Find the product
        Product productToUpdate = null;
        foreach ( var product in inventory )
        {
            if ( product.Name != null && product.Name.ToLower( ) == name.ToLower( ) )
            {
                productToUpdate = product;
                break;
            }
        }

        if ( productToUpdate == null )
        {
            Console.WriteLine( "ERROR: Product not found!" );
            return;
        }

        // Get new price and quantity
        Console.WriteLine( "Enter new price: " );
        decimal newPrice = decimal.Parse( Console.ReadLine( ) );

        if ( newPrice <= 0 )
        {
            Console.WriteLine( "ERROR: Price must be greater than zero!" );
            Console.WriteLine( " " );
            return;
        }

        Console.WriteLine( "Enter new quantity:" );
        int newQuantity = int.Parse( Console.ReadLine( ) );

        // Update the product details
        productToUpdate.Price = newPrice;
        productToUpdate.Quantity = newQuantity;

        Console.WriteLine( "Product updated successfully!" );
        Console.WriteLine( " " );

    }

    private static void DeleteProduct( )
    {
        Console.WriteLine( "\n=== DELETE PRODUCT ===" );

        if ( inventory == null || inventory.Count == 0 )
        {
            Console.WriteLine( "No products available to delete." );
            Console.WriteLine( " " );
            return;
        }

        // Get product name to delete
        Console.WriteLine( "Enter product name to delete:" );
        string name = Console.ReadLine( );

        bool productFound = false;

        if ( string.IsNullOrEmpty( name ) )
        {
            Console.WriteLine( "ERROR: Product name cannot be empty!" );
            Console.WriteLine( " " );
            return;
        }

        // Find the product
        Product productToDelete = null;
        foreach ( var product in inventory )
        {
            if ( product.Name != null )
            {
                if ( product.Name.ToLower( ) == name.ToLower( ) )
                {
                    productToDelete = product; // Found the product to delete
                    break;
                }
            }
        }

        if ( productToDelete == null )
        {
            Console.WriteLine( "ERROR: Product not found!" );
            Console.WriteLine( " " );
            return;
        }

        inventory.Remove( productToDelete );
        Console.WriteLine( "Product deleted successfully!" );
        Console.WriteLine( " " );
    }
}
