using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawPrints
{
    class WebHandeler
    {
        #region GETs
        public static Animal getAnimal(int animalID)
        {
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
        public static List<User> getUsers(int userID)
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
