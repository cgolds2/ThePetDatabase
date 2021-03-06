﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Converters;

namespace PawPrints
{
    class WebHandeler
    {
        public static string baseuri = @"http://68.11.238.103:81/";



        #region Animal
        /// <summary>
        /// Gets animal from server
        /// </summary>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<Animal, int> getAnimal(int animalID)
        {

            string result = (RestService.GetCall(baseuri + "get_pets.php"));
            if (result.Equals("-2"))
            {
                return Tuple.Create((Animal)null, -2);
            }

            PetClass allPets = JsonConvert.DeserializeObject<PetClass>(result);
            foreach (Animal animal in allPets.pets)
            {
                if (animal.id == animalID)
                {
                    return Tuple.Create(animal, 1);
                }
            }
            return null;
        }


        //public static Tuple<List<Animal>, int> getAnimalsByShelter(int shelterID)
        //{

        //    string result = (RestService.GetCall(baseuri + "get_pets.php?id=" + shelterID));
        //    PetClass allPets = JsonConvert.DeserializeObject<PetClass>(result);
        //    List<Animal> ret = new List<Animal>();
        //    int temp;
        //    if (int.TryParse(result, out temp))
        //    {
        //        return Tuple.Create((List<Animal>)null, temp);
        //    }

        //    foreach (Animal animal in allPets.pets)
        //    {
        //        if (animal.shelter_id == shelterID)
        //        {
        //            ret.Add(animal);
        //        }
        //    }
        //    return Tuple.Create(ret, 1);
        //}

        /// <summary>
        /// Gets all animals belonging to shelter with specific id
        /// </summary>
        /// <param name="shelterID"></param>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<List<Animal>, int> getAllAnimals(int shelterID)
        {

            string result = (RestService.GetCall(baseuri + "get_pets.php"));
            PetClass allPets = JsonConvert.DeserializeObject<PetClass>(result);
            List<Animal> ret = new List<Animal>();
            int temp;
            if (int.TryParse(result, out temp))
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

        /// <summary>
        /// Adds pet to server
        /// </summary>
        /// <param name="pet"></param>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int addPet(Animal pet)
        {
            string jsonString = JsonConvert.SerializeObject(pet, Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            MessageBox.Show("JSON STRING" + jsonString);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "add_pet.php"));
            result = result.Trim();
            int temp;
            if (int.TryParse(result, out temp))
            {
                return temp;
            }
            return -2;
        }

        /// <summary>
        /// Updates pet on server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int updatePet(Animal pet)
        {
            string jsonString = JsonConvert.SerializeObject(pet);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "update_pet.php?id=" + pet.id));
            return int.Parse(result);
        }

        /// <summary>
        /// Deletes animal from server
        /// </summary>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static int deleteAnimal(int petID)
        {
            string result = (RestService.PostCall("", baseuri + "delete_pet.php?id=" + petID));
            return int.Parse(result);
        }

        #endregion

        #region Picture
        ////Staged as non critical
        //public static Tuple<List<Image>, int> getAnimalPictures(int animalID)
        //{
        //    throw new NotImplementedException();
        //}

        /// <summary>
        /// Adds profile picture to pet
        /// </summary>
        /// <param name="fileName">File location on disk</param>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static string addPicture(String fileName, int animalID)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            // The byte[] to save the data in
            byte[] data = new byte[fileInfo.Length];

            // Load a filestream and put its content into the byte[]
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);

            }

            String s = RestService.sendImageToUrl("http://68.11.238.103:81/add_profile_picture.php?id="+ animalID, "", data);
            return s;
        }

        /// <summary>
        /// Gets profile picture of pet
        /// </summary>
        /// <param name="petID"></param>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<Image, int> getPicture(int petID)
        {
            try
            {
  
               Image result = (RestService.getImageFromUrl(baseuri + RestService.GetCall(baseuri + "get_profile_picture.php?id=" + petID).Trim()));
                return Tuple.Create(result, 1);

            }
            catch (Exception ex)
            {
                return Tuple.Create((Image)null, -1);
            }

        }



        ////Staged as unnecessary
        //public static int deletePicture(int pictureID)
        //{
        //    throw new NotImplementedException();
        //}
        #endregion

        #region Shelter
        /// <summary>
        /// Gets a list of all shelters on the server
        /// </summary>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<List<Shelter>, int> getAllShelters()
        {
            string result = (RestService.GetCall(baseuri + "get_shelters.php"));
            int temp;
            if (int.TryParse(result, out temp))
            {
                return Tuple.Create((List<Shelter>)null, temp);
            }
            ShelterClass totalList = JsonConvert.DeserializeObject<ShelterClass>(result);
            return Tuple.Create(totalList.shelters, 1);
        }

        /// <summary>
        /// Gets shelter on server with specific id
        /// </summary>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<Shelter, int> getShelterByID(int shelterID)
        {
            string result = (RestService.GetCall(baseuri + "get_shelters.php?id=" + shelterID));
            int temp;
            if (int.TryParse(result, out temp))
            {
                return Tuple.Create((Shelter)null, temp);
            }
            ShelterClass totalList = JsonConvert.DeserializeObject<ShelterClass>(result);
            return Tuple.Create(totalList.shelters[0], 1);
        }

        /// <summary>
        /// Creates shelter on the server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int createShelter(Shelter shelter)
        {
            string jsonString = JsonConvert.SerializeObject(shelter);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "add_shelter.php"));

            return int.Parse(result);
        }

        /// <summary>
        /// Updates shelter on the server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int updateShelter(Shelter shelter)
        {
            string jsonString = JsonConvert.SerializeObject(shelter);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "update_pet.php?id=" + shelter.id));
            return int.Parse(result);
        }

        /// <summary>
        /// Deletes shelter on the server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int deleteShelter(int shelterID)
        {
            string result = (RestService.PostCall("", baseuri + "delete_shelter.php?id=" + shelterID));
            return int.Parse(result);
        }
        #endregion

        #region User
        /// <summary>
        /// Updates user on the server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int updateUser(User user)
        {
            string jsonString = JsonConvert.SerializeObject(user);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "update_pet.php?id=" + user.id));
            return int.Parse(result);
        }

        /// <summary>
        /// Gets a list of all users that belong to a specific shelter
        /// </summary>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<List<User>, int> getAllUsers(int shelterID)
        {
            string result = (RestService.GetCall(baseuri + "get_users.php?id=" + shelterID));
            int temp;
            if (int.TryParse(result, out temp))
            {
                return Tuple.Create((List<User>)null, temp);
            }
            UserClass totalList = JsonConvert.DeserializeObject<UserClass>(result);
            return Tuple.Create(totalList.users, 1);
        }

        /// <summary>
        /// Creates user on the server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int createUser(User user)
        {
            string jsonString = JsonConvert.SerializeObject(user);
            JObject ob = JObject.Parse(jsonString);
            string result = (RestService.PostCall(ob.ToString(), baseuri + "add_user.php"));
            result = result.Trim();
            if (result.Equals("-1"))
            {
                return -1;
            }
            if (result.Equals("-2"))
            {
                return -2;
            }
            return int.Parse(result);
        }

        /// <summary>
        /// Deletes user on the server
        /// </summary>
        /// <returns>-1 if server error, -2 if can't connect to server</returns>
        public static int deleteUsers(int userID)
        {
            string result = (RestService.PostCall("", baseuri + "delete_user.php?id=" + userID));
            if (result.Equals("1"))
            {
                return 1;
            }
            if (result.Equals("-2"))
            {
                return -2;
            }
            return -1;
        }

        /// <summary>
        /// Verifies that the password is correct for the specific username
        /// </summary>
        /// <param name="password">unhashed</param>
        /// <returns>int is -1 if server error, -2 if can't connect to server</returns>
        public static Tuple<User, int> verifyUser(string username, string password)
        {
            JObject ob = new JObject();
            ob["username"] = username;
            ob["password"] = password;

            string result = (RestService.PostCall(ob.ToString(), baseuri + "verify_user.php"));
            result = result.Trim();
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

        /// <summary>
        /// Returns if user is an admin
        /// </summary>
        public static bool isUserAdmin(User u)
        {
            string result = (RestService.GetCall(baseuri + "is_admin.php?uid=" + u.id + "&sid=" + u.shelter_id));

            return bool.Parse(result);
        }
        #endregion


    }
    /*These next three classes are only used so that
     * the JSON data sent to the server is correctly 
     * formatted 
     */
    #region JSON format classes
    class PetClass
    {
        public List<Animal> pets { get; set; }
    }
    class ShelterClass
    {
        public List<Shelter> shelters { get; set; }
    }
    class UserClass
    {
        public List<User> users { get; set; }
    }
    #endregion

}
