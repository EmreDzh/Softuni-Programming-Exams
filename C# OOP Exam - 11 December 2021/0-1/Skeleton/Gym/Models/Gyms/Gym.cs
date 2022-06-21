using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
       
        private int AthleteCount = 0;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Gym name cannot be null or empty.");
                }

                this.name = value;
            }
        }
        public int Capacity { get; }
        public double EquipmentWeight => this.Equipment.Sum(x => x.Weight);
        public ICollection<IEquipment> Equipment { get; }
        public ICollection<IAthlete> Athletes { get; }
        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity) //TODO MIGHT BE == CHECK IF WRONG
            {
                throw new InvalidOperationException("Not enough space in the gym.");
            }
            this.Athletes.Add(athlete);
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var VARIABLE in this.Athletes)
            {
                VARIABLE.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");

            if (this.Athletes.Any())
            {
                sb.AppendLine($"Athletes: " + string.Join(", ", this.Athletes));
            }
            else
            {
                sb.AppendLine("Athletes: No athletes");
            }

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");
            
            return sb.ToString().Trim();
        }
    }
}