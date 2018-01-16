﻿using Hassie.API.NewsAPI.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hassie.API.NewsAPI.Models
{
    internal class NewsArticles : INewsArticles
    {
        private List<INewsArticle> articles = new List<INewsArticle>();

        public NewsArticles(JObject json)
        {
            try
            {
                // Get array with articles.
                JArray array = (JArray)json["articles"];

                // Extract each article and add to list.
                foreach (JObject article in array)
                {
                    string author = (string)article["author"];
                    string description = (string)article["description"];
                    string imageURL = (string)article["urlToImage"];
                    DateTimeOffset publishTime = DateTimeOffset.Parse(article["publishedAt"].ToString());
                    string sourceName = (string)article["source"]["name"];
                    string title = (string)article["title"];
                    string url = (string)article["url"];
                    NewsArticle newsArticle = new NewsArticle(author, description, imageURL, publishTime, sourceName, title, url);
                    articles.Add(newsArticle);
                }
            }
            catch (JsonException e)
            {
                throw new NewsJSONException("News API JSON Exception - Failed to extract JSON:", e);
            }
        }

        public List<INewsArticle> Articles => articles;
    }
}
