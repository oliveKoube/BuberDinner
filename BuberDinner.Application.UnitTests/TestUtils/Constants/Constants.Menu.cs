﻿namespace BuberDinner.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Menu
    {
        public const string Name = "Menu Name";
        public const string Description = "Menu Description";
        public const string SectionName = "Menu Section Name";
        public const string SectionDescription = "Menu Section Description";
        public const string ItemName = "Menu Item Name";
        public const string ItemDescription = "Menu Item Description";
        
        public static string SectionNameFromGivenIndex(int index) 
            => $"{SectionName} {index}";
        public static string SectionDescriptionFromGivenIndex(int index)
            => $"{SectionDescription} {index}";
        public static string ItemNameFromGivenIndex(int index) 
            => $"{ItemName} {index}";
        public static string ItemDescriptionFromGivenIndex(int index) 
            => $"{ItemDescription} {index}";
    }
}