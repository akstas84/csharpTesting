﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests

{
    public class GroupData : IEquatable<GroupData>
    {
        private string name;
        private string header;
        private string footer;

        public GroupData()
        {
        }

        public GroupData(string name)
        {
            this.name = name;
        }

        public GroupData(string name, string header)
        {
            this.name = name;
            this.header = header;
        }

        public GroupData(string name, string header, string footer)
        {
            this.name = name;
            this.header = header;
            this.footer = footer;
        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, null))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int HashCode => Name.GetHashCode();

        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
            }
        }

        public string Footer
        {
            get
            {
                return footer;
            }
            set
            {
                footer = value;
            }
        }
    }
}
