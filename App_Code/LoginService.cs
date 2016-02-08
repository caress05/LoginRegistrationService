﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LoginService" in code, svc and config file together.
public class LoginService : ILoginService
{
    ShowTrackerEntities db = new ShowTrackerEntities();

	public int VenueLogin(string password, string username)
    {
        int result = db.usp_venueLogin(username, password);
        if(result !=-1)
        {
            var key = from k in db.VenueLogins
                      where k.VenueLoginUserName.Equals(username)
                      select new { k.VenueLoginKey };
            foreach(var k in key)
            {
                result=(int)k.VenueLoginKey;
            }
        }
        return result;
    }

    public int VenueRegistration(VenueLite v)
    {
        Venue ve = new Venue();

        int result = db.usp_RegisterVenue(v.Name, v.Address, v.City, v.State, v.ZipCode, v.Phone, v.Email, v.WebPage, v.AgeRestriction, v.UserName, v.Password);

        return result;
    }
}
