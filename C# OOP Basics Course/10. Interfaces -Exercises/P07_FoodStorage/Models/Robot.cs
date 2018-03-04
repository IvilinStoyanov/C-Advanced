using System;
using System.Collections.Generic;
using System.Text;

namespace P07_FoodStorage.Models
{
    using Interfaces;

    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }
    }
}