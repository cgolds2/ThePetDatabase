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
        public static string baseuri = @"http://68.11.238.103:812/";



        #region Animal
        public static Tuple<Animal, int> getAnimal(int animalID)
        {

            string text = (RestService.GetCall(baseuri + "get_pets.php"));
            if (text.Equals("-2"))
            {
                return Tuple.Create((Animal)null, -2);
            }

            PetClass allPets = JsonConvert.DeserializeObject<PetClass>(text);
            foreach (Animal animal in allPets.pets)
            {
                if (animal.id == animalID)
                {
                    return Tuple.Create(animal, 1);
                }
            }
            return null;
        }
        public static Tuple<List<Animal>, int> getAllAnimals(int shelterID)
        {

            string text = (RestService.GetCall(baseuri + "get_pets.php"));
            PetClass allPets = JsonConvert.DeserializeObject<PetClass>(text);
            List<Animal> ret = new List<Animal>();
            int temp;
            if (int.TryParse(text, out temp))
            {
                return Tuple.Create((List<Animal>)null, temp);
            }

            foreach (Animal animal in allPets.pets)
            {
                if (animal.shelter_id == shelterID)
                {
                    ret.Add(animal);
                }
            }
            return Tuple.Create(ret, 1);

        }
        public static int addPet(Animal pet)
        {
            string jsonString = JsonConvert.SerializeObject(pet);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "add_pet.php"));
            if (result.Equals(-1))
            {
                return -1;
            }
            if (result.Equals("-2"))
            {
                return -2;
            }
            return 1;
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
        public static Tuple<List<Image>, int> getAnimalPictures(int animalID)
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
        public static Tuple<List<Shelter>, int> getAllShelters()
        {
            string returnText = (RestService.GetCall(baseuri + "get_shelters.php"));
            int temp;
            if (int.TryParse(returnText, out temp))
            {
                return Tuple.Create((List<Shelter>)null, temp);
            }
            ShelterClass totalList = JsonConvert.DeserializeObject<ShelterClass>(returnText);
            return Tuple.Create(totalList.shelters, 1);
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
        public static Tuple<List<User>, int> getUsers(int userID)
        {
            throw new NotImplementedException();
        }
        public static Tuple<List<User>, int> createUser(User user)
        {
            throw new NotImplementedException();
        }
        public static int deleteUsers(int userID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// -1 on fail, -2 on server timeout, 1 on response
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password">Unhashed</param>
        /// <returns>-1 on fail, -2 on server timeout, 1 on response</returns>
        public static Tuple<User, int> verifyUser(string username, string password)
        {
            JObject ob = new JObject();
            ob["username"] = username;
            ob["password"] = password;

            string result = (RestService.PostCall(ob.ToString(), baseuri + "verify_user.php"));
            if (result.Equals("-1") || result.Equals("\n{\"error\":\"Incorrect username or password.\"}"))
            {
                return Tuple.Create((User)null, -1);
            }
            if (result.Equals("-2"))
            {
                return Tuple.Create((User)null, -2);
            }
            User u = JsonConvert.DeserializeObject<User>(result);
            return Tuple.Create(u, 1);
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
