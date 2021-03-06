﻿using Bogus;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamsSampleTaskApp.DataModel;

namespace TeamsSampleTaskApp.Utils
{
    public static class Utils
    {
        // TODO: move to SDK function
        public static string GetTextWithoutMentions(this Activity activity)
        {
            var text = activity.Text;
            if (activity.Entities != null)
            {
                var mentions = activity.Entities.Where(e => e.Type == "mention");
                foreach (var m in mentions)
                {
                    text = text.Replace(m.Properties["text"].ToString(), String.Empty);
                }
                text = text.Trim();
            }
            return text;
        }

        public static TaskItem CreateTaskItem()
        {
            var faker = new Faker();
            return new TaskItem()
            {
                Title = faker.Commerce.ProductName(),
                Description = faker.Lorem.Sentence(),
                Assigned = $"{faker.Name.FirstName()} {faker.Name.LastName()}",
                Guid = Guid.NewGuid().ToString()
            };
        }

    }

    public class TabContext
    {
        public string ChannelId { get; set; }
        public string CanvasUrl { get; set; }
    }

}