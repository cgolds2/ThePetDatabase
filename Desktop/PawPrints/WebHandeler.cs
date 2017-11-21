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
        public static string baseuri = "http://192.168.3.3/";

        public static JObject getJsonObject(string url)
        {
            string longUrl = baseuri + url;
            string text = (RestService.GetCall(longUrl));
            dynamic dynReturn = JObject.Parse(text);
            return dynReturn;
        }

        #region GETs
        public static Animal getAnimal(int animalID)
        {
            string returnText = RestService.GetCall(baseuri + "");
            Animal returnAnimal = JsonConvert.DeserializeObject<Animal>(returnText);
            throw new NotImplementedException();
        }
        public static List<Animal> getAllAnimals(int shelterID)
        {
            throw new NotImplementedException();
        }
        public static List<Image> getAnimalPictures(int animalID)
        {
            throw new NotImplementedException();
        }
        public static List<Shelter> getShelters()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region POSTs
        public static int addPet(Animal pet)
        {
            string jsonString = JsonConvert.SerializeObject(pet);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + ""));
            return int.Parse(result);
            throw new NotImplementedException();
        }
        public static int updatePet(Animal pet, int petID)
        {
            throw new NotImplementedException();
        }
        public static int createShelter(Shelter shelter)
        {
            throw new NotImplementedException();
        }
        public static int updateShelter(Shelter shelter, int shelterID)
        {
            throw new NotImplementedException();
        }
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
        public static int addPicture(Image picture)
        {
            throw new NotImplementedException();
        }
        public static int deletePicture(int pictureID)
        {
            throw new NotImplementedException();
        }
        public static int deleteUsers(int userID)
        {
            throw new NotImplementedException();
        }
        public static int deleteShelter(int shelterID)
        {
            throw new NotImplementedException();
        }
        public static int deletePet(int petID)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
