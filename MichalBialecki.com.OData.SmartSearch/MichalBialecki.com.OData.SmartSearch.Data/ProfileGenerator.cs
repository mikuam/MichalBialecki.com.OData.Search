﻿using Bogus;
using System;
using System.Collections.Generic;

namespace MichalBialecki.com.OData.SmartSearch.Data
{
    public class ProfileGenerator
    {
        public List<ProfileDto> GenerateProfiles(int count)
        {
            var profileGenerator = new Faker<ProfileDto>()
                .RuleFor(p => p.Id, v => Guid.NewGuid().ToString())
                .RuleFor(p => p.FirstName, v => v.Person.FirstName)
                .RuleFor(p => p.LastName, v => v.Person.LastName)
                .RuleFor(p => p.UserName, v => v.Person.UserName)
                .RuleFor(p => p.Email, v => v.Person.Email)
                .RuleFor(p => p.Street, v => v.Person.Address.Street)
                .RuleFor(p => p.City, v => v.Person.Address.City)
                .RuleFor(p => p.ZipCode, v => v.Person.Address.ZipCode)
                .RuleFor(p => p.Country, v => v.Address.Country())
                .RuleFor(p => p.PhoneNumber, v => v.Person.Phone)
                .RuleFor(p => p.Website, v => v.Person.Website)
                .RuleFor(p => p.CompanyName, v => v.Company.CompanyName())
                .RuleFor(p => p.Notes, v => v.Lorem.Text());

            return profileGenerator.Generate(count);
        }
    }
}
