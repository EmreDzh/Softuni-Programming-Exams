using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;

namespace Gym.Core
{
    public class Controller : IController
    {
        private IRepository<IEquipment> equipments = new EquipmentRepository();
        private List<IGym> gyms = new List<IGym>();
        private int athletesTrainedCounter = 0;

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException("Invalid gym type.");
            }

            this.gyms.Add(gym);

            return $"Successfully added {gymType}";
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;

            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }

            this.equipments.Add(equipment);

            return $"Successfully added {equipmentType}.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
             var findThe =  this.equipments.FindByType(equipmentType);

             if (findThe == null)
             {
                 throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
             }

             IGym findTheGym = this.gyms.FirstOrDefault(x => x.Name == gymName);  //TODO CHECK FOR THIS PROBLEM

             findTheGym.AddEquipment(findThe);

             return $"Successfully added {equipmentType} to {gymName}.";

        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete;
            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                    default:
                        throw new InvalidOperationException("Invalid athlete type.");
            }

            var getTheGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if (athleteType == "Boxer" && getTheGym.GetType().Name != nameof(BoxingGym))
            {
                return "The gym is not appropriate.";
            }
            else if (athleteType == "Weightlifter" && getTheGym.GetType().Name != nameof(WeightliftingGym))
            {
                return "The gym is not appropriate.";
            }

            getTheGym.AddAthlete(athlete);

            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string TrainAthletes(string gymName)
        {
            var getTheGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            getTheGym.Exercise();
            this.athletesTrainedCounter++;  

            return $"Exercise athletes: {this.athletesTrainedCounter}.";

        }

        public string EquipmentWeight(string gymName)
        {
            var getTheGym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            var value = getTheGym.EquipmentWeight;

            return $"The total weight of the equipment in the gym {gymName} is {value:F2} grams.";
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var VARIABLE in this.gyms)
            {
                sb.AppendLine(VARIABLE.GymInfo());
            }

            return sb.ToString().Trim();

        }
    }
}