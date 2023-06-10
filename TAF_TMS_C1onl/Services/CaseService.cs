﻿using Newtonsoft.Json.Linq;
using RestSharp;
using TAF_TMS_C1onl.Clients;
using TAF_TMS_C1onl.Models;
using TAF_TMS_C1onl.Utilites.Configuration;
using TAF_TMS_C1onl.Utilites.Helpers;

namespace TAF_TMS_C1onl.Services
{
    public class CaseService : BaseService
    {
        public static readonly string GET_CASE = "index.php?/api/v2/get_case/{case_id}";
        public static readonly string ADD_CASE = "index.php?/api/v2/add_case/{section_id}";
        public static readonly string UPDATE_CASE = "index.php?/api/v2/update_case/{case_id}";
        public static readonly string DELETE_CASE = "index.php?/api/v2/delete_case/{case_id}";

        public CaseService(ApiClient apiClient) : base(apiClient)
        {
        }

        public RestResponse GetCase(int caseId)
        {
            var request = new RestRequest(GET_CASE)
                .AddUrlSegment("case_id", caseId);

            return _apiClient.Execute(request);
        }

        public RestResponse AddCase(Case testCase, int sectionId)
        {
            var request = new RestRequest(ADD_CASE, Method.Post)
                .AddUrlSegment("section_id", sectionId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(testCase);

            return _apiClient.Execute(request);
        }

        public RestResponse UpdateCase(Case testCase, int caseId)
        {
            var request = new RestRequest(UPDATE_CASE, Method.Post)
                .AddUrlSegment("case_id", caseId)
                .AddHeader("Content-Type", "application/json")
                .AddBody(testCase);

            return _apiClient.Execute(request);
        }

        public RestResponse DeleteCase(int caseId)
        {
            var request = new RestRequest(DELETE_CASE, Method.Post)
                .AddUrlSegment("case_id", caseId)
                .AddHeader("Content-Type", "application/json");

            return _apiClient.Execute(request);
        }
    }
}