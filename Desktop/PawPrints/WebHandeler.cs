using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PawPrints
{
    class WebHandeler
    {
        public static string baseuri = @"http://68.11.238.103:81/";

        public static JObject getJsonObject(string url)
        {
            string longUrl = baseuri + url;
            string text = (RestService.GetCall(longUrl));
            dynamic dynReturn = JObject.Parse(text);
            return dynReturn;
        }


        #region Animal
        public static Animal getAnimal(int animalID)
        {

            string text = (RestService.GetCall(baseuri + "get_pets.php"));
            PetClass allPets = JsonConvert.DeserializeObject<PetClass>(text);
            foreach (Animal animal in allPets.pets)
            {
                if (animal.id == animalID)
                {
                    return animal;
                }
            }
            return null;
        }
        public static List<Animal> getAllAnimals(int shelterID)
        {

            string text = (RestService.GetCall(baseuri + "get_pets.php"));
            PetClass allPets = JsonConvert.DeserializeObject<PetClass>(text);
            List<Animal> ret = new List<Animal>();

            foreach (Animal animal in allPets.pets)
            {
                if (animal.shelter_id == shelterID)
                {
                    ret.Add(animal);
                }
            }
            return ret;

        }
        public static int addPet(Animal pet)
        {
            string jsonString = JsonConvert.SerializeObject(pet);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "add_pet.php"));
            return int.Parse(result);
        }
        public static int updatePet(Animal pet)
        {
            string jsonString = JsonConvert.SerializeObject(pet);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "update_pet.php?id=" + pet.id));
            return int.Parse(result);
        }
        public static int deleteAnimal(int petID)
        {
            string result = (RestService.PostCall("", baseuri + "delete_pet?id=" + petID));
            return int.Parse(result);
        }

        #endregion

        #region Picture
        public static List<Image> getAnimalPictures(int animalID)
        {
            throw new NotImplementedException();
        }
        public static int addPicture(Image picture)
        {
            throw new NotImplementedException();
        }
        public static int deletePicture(int pictureID)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Shelter
        public static List<Shelter> getAllShelters()
        {
            string returnText = (RestService.GetCall(baseuri + "get_shelters.php"));
            ShelterClass totalList = JsonConvert.DeserializeObject<ShelterClass>(returnText);
            return totalList.shelters;
        }
        public static int createShelter(Shelter shelter)
        {
            string jsonString = JsonConvert.SerializeObject(shelter);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "add_shelter.php"));
            return int.Parse(result);
        }
        public static int updateShelter(Shelter shelter)
        {
            string jsonString = JsonConvert.SerializeObject(shelter);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "update_pet.php?id=" + shelter.id));
            return int.Parse(result);
        }
        public static int deleteShelter(int shelterID)
        {
            string result = (RestService.PostCall("", baseuri + "delete_shelter?id=" + shelterID));
            return int.Parse(result);
        }
        #endregion

        #region User
        public static int updateUser(User user, int userID)
        {
            throw new NotImplementedException();
        }
        public static List<User> getUsers(int userID)
        {
            throw new NotImplementedException();
        }
        public static List<User> createUser(User user)
        {
            throw new NotImplementedException();
        }
        public static int deleteUsers(int userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// user id if true, returns -1 if false
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">Unhashed</param>
        /// <returns>-1 on fail, user id on true</returns>
        public static User verifyUser(string username, string password)
        {
            JObject ob = new JObject();
            ob["username"] = username;
            ob["password"] = password;

            string result = (RestService.PostCall(ob.ToString(), baseuri + "verify_user.php"));
            if (result.Equals("-1"))
            {
                return null;
            }
           User u = JsonConvert.DeserializeObject<User>(result);
            return u;
        }
        #endregion


    }
     class PetClass
    {
        public List<Animal> pets { get; set; }
    }
    class ShelterClass
    {
        public List<Shelter> shelters { get; set; }
    }
}
