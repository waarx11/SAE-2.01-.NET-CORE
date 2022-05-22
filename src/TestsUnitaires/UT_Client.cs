using System;
using Modele;
using System.Collections.Generic;
using Xunit;

namespace TestsUnitaires
{
    public class UT_Client
    {
        [Theory]
        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", false)] // tout bon

        [InlineData("", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Non-renseign�", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", false)] // Prenom vide

        [InlineData("Bonneau", "", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Non-renseign�", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", false)] // Nom vide

        [InlineData("Bonneau", "Baptiste", "", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", true)] // Email vide

        [InlineData("Bonneau", "Baptiste", "emailMarchePas", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", true)] // Email sans @

        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "Non-renseign�", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", false)] // telephone vide

        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "Non-renseign�", "Clermont-Ferrand", "63000", "default\noImg.png", false)] // Adresse vide

        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "", "63000", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Non-renseign�", "63000", "default\noImg.png", false)] // Ville vide

        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "", "Bapt", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "00000", "default\noImg.png", false)] // CodePostal vide

        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noPP.jpg", false)] // Image vide

        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "", "default\noImg.png",
                    "Bonneau", "Baptiste", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "default\noImg.png", true)] // Pseudo vide

        public void TEST_Ctor(string nom, string pr�nom, string email, string t�l�phone, string adresse, string ville, string codePostal, string pseudo, string photo,
                              string expNom, string expPr�nom, string expT�l�phone, string expAdresse, string expVille, string expCodePostal, string expPhoto, bool shouldThrowException)
        {

            if (shouldThrowException)
            {
                Assert.Throws<ArgumentException>(() => new Client(nom, pr�nom, email, t�l�phone, adresse, ville, codePostal, pseudo, photo));
                return;
            }
            
            Client c = new Client(nom, pr�nom, email, t�l�phone, adresse, ville, codePostal, pseudo, photo);
            Assert.Equal(expNom, c.Nom);
            Assert.Equal(expPr�nom, c.Pr�nom);
            Assert.Equal(expT�l�phone, c.T�l�phone);
            Assert.Equal(expAdresse, c.Adresse);
            Assert.Equal(expVille, c.Ville);
            Assert.Equal(expCodePostal, c.CodePostal);
            Assert.Equal(expPhoto, c.Photo);

        }

        [Theory]
        [InlineData("Bonneau", "Baptiste", "baptiste.bonneau@etu.uca.fr", "0612345678", "37 rue thisIsMonAdresse", "Clermont-Ferrand", "63000", "Bapt", "default\noImg.png")]
        public void TEST_ToString(string nom, string pr�nom, string email, string t�l�phone, string adresse, string ville, string codePostal, string pseudo, string photo)
        {
            List<Ingredients> liste = new List<Ingredients> { (Ingredients)53, (Ingredients)0 };
            Client c = new Client(nom, pr�nom, email, t�l�phone, adresse, ville, codePostal, pseudo, photo);
            string expectedAfficher = $"{nom} {pr�nom} {email} {t�l�phone} {adresse} {ville} {codePostal} {pseudo} {photo}";
            Assert.Equal(expectedAfficher, c.ToString());
        }


    }
}