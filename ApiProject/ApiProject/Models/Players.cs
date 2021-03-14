using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace ApiProject.Models
{
    //public class Internal
    //{

    //    [JsonPropertyName("pubDateTime")]
    //    public string PubDateTime { get; set; }

    //    [JsonPropertyName("igorPath")]
    //    public string IgorPath { get; set; }

    //    [JsonPropertyName("xslt")]
    //    public string Xslt { get; set; }

    //    [JsonPropertyName("xsltForceRecompile")]
    //    public string XsltForceRecompile { get; set; }

    //    [JsonPropertyName("xsltInCache")]
    //    public string XsltInCache { get; set; }

    //    [JsonPropertyName("xsltCompileTimeMillis")]
    //    public string XsltCompileTimeMillis { get; set; }

    //    [JsonPropertyName("xsltTransformTimeMillis")]
    //    public string XsltTransformTimeMillis { get; set; }

    //    [JsonPropertyName("consolidatedDomKey")]
    //    public string ConsolidatedDomKey { get; set; }

    //    [JsonPropertyName("endToEndTimeMillis")]
    //    public string EndToEndTimeMillis { get; set; }
    //}

    public class TeamSitesOnly
    {

        [JsonPropertyName("playerCode")]
        public string PlayerCode { get; set; }

        [JsonPropertyName("posFull")]
        public string PosFull { get; set; }

        [JsonPropertyName("displayAffiliation")]
        public string DisplayAffiliation { get; set; }

        [JsonPropertyName("freeAgentCode")]
        public string FreeAgentCode { get; set; }
    }

    public class PlayerTeam
    {

        [JsonPropertyName("teamId")]
        public string TeamId { get; set; }

        [JsonPropertyName("seasonStart")]
        public string SeasonStart { get; set; }

        [JsonPropertyName("seasonEnd")]
        public string SeasonEnd { get; set; }
    }

    public class Draft
    {

        [JsonPropertyName("teamId")]
        public string TeamId { get; set; }

        [JsonPropertyName("pickNum")]
        public string PickNum { get; set; }

        [JsonPropertyName("roundNum")]
        public string RoundNum { get; set; }

        [JsonPropertyName("seasonYear")]
        public string SeasonYear { get; set; }
    }

    public class Player
    {

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("temporaryDisplayName")]
        public string TemporaryDisplayName { get; set; }

        [JsonPropertyName("personId")]
        public string PersonId { get; set; }

        [JsonPropertyName("teamId")]
        public string TeamId { get; set; }

        [JsonPropertyName("jersey")]
        public string Jersey { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("pos")]
        public string Pos { get; set; }

        [JsonPropertyName("heightFeet")]
        public string HeightFeet { get; set; }

        [JsonPropertyName("heightInches")]
        public string HeightInches { get; set; }

        [JsonPropertyName("heightMeters")]
        public string HeightMeters { get; set; }

        [JsonPropertyName("weightPounds")]
        public string WeightPounds { get; set; }

        [JsonPropertyName("weightKilograms")]
        public string WeightKilograms { get; set; }

        [JsonPropertyName("dateOfBirthUTC")]
        public string DateOfBirthUTC { get; set; }

        [JsonPropertyName("teamSitesOnly")]
        public TeamSitesOnly TeamSitesOnly { get; set; }

        [JsonPropertyName("teams")]
        public IList<PlayerTeam> Teams { get; set; }

        [JsonPropertyName("draft")]
        public Draft Draft { get; set; }

        [JsonPropertyName("nbaDebutYear")]
        public string NbaDebutYear { get; set; }

        [JsonPropertyName("yearsPro")]
        public string YearsPro { get; set; }

        [JsonPropertyName("collegeName")]
        public string CollegeName { get; set; }

        [JsonPropertyName("lastAffiliation")]
        public string LastAffiliation { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("isallStar")]
        public bool? IsallStar { get; set; }
    }

    public class LeaguePlayer
    {

        [JsonPropertyName("standard")]
        public IList<Player> Standard { get; set; }

        //[JsonPropertyName("africa")]
        //public IList<object> Africa { get; set; }

        //[JsonPropertyName("sacramento")]
        //public IList<object> Sacramento { get; set; }

        //[JsonPropertyName("vegas")]
        //public IList<object> Vegas { get; set; }

        //[JsonPropertyName("utah")]
        //public IList<object> Utah { get; set; }
    }

    public class Players : INotifyPropertyChanged
    {

        //[JsonPropertyName("_internal")]
        //public Internal Internal { get; set; }

        [JsonPropertyName("league")]
        public LeaguePlayer League { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }


}
