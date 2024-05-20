﻿using LINQApp.Model;

namespace UnderstandingLINQApp
{
    internal class Program
    {
        void PrintTheBooksPulisherwise()
        {
            pubsContext context = new pubsContext();
            var books = context.Titles
                        .GroupBy(t => t.PubId, t => t, (pid, title) => new { Key = pid, TitleCount = title.Count(), TitleNames = title.ToList() });

            foreach (var book in books)
            {
                Console.Write(book.Key);
                Console.WriteLine(" - " + book.TitleCount);
                Console.WriteLine("BookNames");
                foreach (var title in book.TitleNames)
                {
                    Console.WriteLine(title.Title1);
                }
            }
        }
        //void PrintTheBooksPulisherwise()
        //{
        //    pubsContext context = new pubsContext();
        //    var books = context.Titles
        //                .GroupBy(t => t.PubId)
        //                .Select(t => new {
        //                    PublisherId = t.Key,
        //                    TitleCount = t.Count(),
        //                    Titles = t.Select(t => new
        //                    {
        //                        BookName = t.Title1,
        //                        BookPrice = t.Price
        //                    })
        //                });

        //    foreach (var book in books)
        //    {
        //        Console.Write(book.PublisherId);
        //        Console.WriteLine(" - " + book.TitleCount);
        //        foreach (var title in book.Titles)
        //        {
        //            Console.WriteLine("\t"+ title.BookName+" "+title.BookPrice);
        //        }
        //    }
        //}
        void PrintNumberOfBooksFromType(string type)
        {
            pubsContext context = new pubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            pubsContext context = new pubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }
        void PrintTitleIdQuantityAndOrderId()
        {
            pubsContext pubsContext = new pubsContext();
            var orders = pubsContext.Sales
                            .GroupBy(s => s.TitleId)
                            .Select(s => new
                            {
                                Id = s.Key,
                                OrderDetails = s.Select(s => new
                                {
                                    OrderId = s.OrdNum,
                                    Quantity = s.Qty
                                })
                            });
            foreach (var order in orders)
            {
                Console.WriteLine("Title is");
                Console.WriteLine(order.Id);

                Console.WriteLine("Order details are ");
                foreach (var item in order.OrderDetails)
                {
                    Console.WriteLine(item.OrderId);
                    Console.WriteLine(item.Quantity);
                }
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            //program.PrintTheBooksPulisherwise();
            program.PrintTitleIdQuantityAndOrderId();
        }
    }
}
