﻿using System;

namespace AnimalRescue.Contracts.BusinessLogic.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class CouplingPropertyDtoAttribute : Attribute
    {
        public string AliasName { get; set; }
        public CouplingPropertyDtoAttribute(string name)
        {
            AliasName = name;
        }
    }
}
