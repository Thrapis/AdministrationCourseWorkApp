using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheRamShop.Models.PageModels
{
    public class Review
    {
        public ProductInfo Product { get; private set; }
        public string Author { get; private set; }
        public float Stars { get; private set; }
        public string ReviewText { get; private set; }

        public Review(ProductInfo product, string author, float stars, string reviewText)
        {
            Product = product;
            Author = author;
            Stars = stars;
            ReviewText = reviewText;
        }

        public string GetDotDelimetrStars()
        {
            return Stars.ToString().Replace(",", ".");
        }

        public string GetCuttedReview(int symbols)
        {
            return ReviewText.Length > symbols ? ReviewText.Substring(0, symbols) + "..." : ReviewText;
        }
    }
}