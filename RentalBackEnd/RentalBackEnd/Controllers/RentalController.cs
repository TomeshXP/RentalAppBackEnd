using Newtonsoft.Json.Linq;
using RentalBackEnd.Custom_Method;
using RentalBackEnd.Custom_Model;
using RentalBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebGrease.Css.Ast;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace RentalBackEnd.Controllers
{
    public class RentalController : ApiController
    {
        // GET: Rental

        RentalMethod rentalMethod;
       public RentalController()
        {
            rentalMethod = new RentalMethod();
        }

        [HttpPost]
        [Route("api/AddLandLord")]
        public HttpResponseMessage AddLandLord(LandlordPostModel landlordPostModel)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            Response<LandlordPostModel> response = new Response<LandlordPostModel>();
            try
            {
                response.Status = true;
                response.Data = rentalMethod.AddLandLord(landlordPostModel);
                if (response.Data != null)
                {
                    response.Message = "Record Added Successfully...!";
                }
                else
                {
                    response.Message="Password Incorrent";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            //response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(response));
            //return response;
            responseMessage = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(response));
            return responseMessage;
        }


        [HttpPost]
        [Route("api/LandlordLogin")]

        public HttpResponseMessage LandlordLogin(LandlordLogin landlordLogin)
        {
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            Response<LandlordLogin> response = new Response<LandlordLogin>();
            LandlordLogin landloginresponse = new LandlordLogin();
            try
            {
                response.Status = true;
                
                var result= rentalMethod.AddLandlordLogin(landlordLogin);
                if(result!=null)
                {
                    response.Data=result;
                    response.Message = "Login Successfully...!";
                }
                else
                {
                    response.Message = "Login Failed";
                }
                
               
            }
            catch(Exception ex)
            {
                throw ex;
            }
            httpResponse = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(response));
            return httpResponse;
        }


        [HttpPost]
        [Route("api/AddProperty")]

        public HttpResponseMessage AddProperty(AddPropertyPostModel addPropertyPostModel)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            Response<AddPropertyPostModel> response = new Response<AddPropertyPostModel>();
            try
            {
                response.Status = true;
                response.Data = rentalMethod.AddProperty(addPropertyPostModel);
                response.Message = "Property Added Successfully..!";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            responseMessage = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(response));
            return responseMessage;
        }


        [HttpGet]
        [Route("api/GetAllProperty/{RentarId}")]

        public HttpResponseMessage GetAllProperty(int RentarId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response<List<PropertyResponseModel>> responses = new Response<List<PropertyResponseModel>>();
            try
            {
                responses.Status = true;
                responses.Data = rentalMethod.GetAllProperty(RentarId);
                responses.Message = "Property Got Successfully....";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responses));
            return response;

        }




        [HttpGet]
        [Route("api/getMyProperties/{RentarId}")]

        public HttpResponseMessage getMyProperties(int RentarId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response<List<PropertyResponseModel>> responses = new Response<List<PropertyResponseModel>>();
            try
            {
                responses.Status = true;
                responses.Data = rentalMethod.getMyProperties(RentarId);
                responses.Message = "Property Got Successfully....";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responses));
            return response;

        }


        [HttpDelete]
        [Route("api/DeleteProperty/{PropertyId}")]

        public HttpResponseMessage DeleteProperty(int PropertyId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response<LandlordLogin> response1 = new Response<LandlordLogin>();
            try
            {
                var result=rentalMethod.DeleteProperty(PropertyId);
                if(result==true)
                {
                    response1.Message = "Property Deleted Successfully...!";
                }
                else
                {
                   response1.Message="Not Deleted";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(response1));
            return response;

        }
        [HttpGet]
        [Route("api/GetPropertyById/{PropertyId}")]

        public HttpResponseMessage GetPropertyById(int PropertyId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response<PropertyResponseModel> responsess = new Response<PropertyResponseModel>();
            try
            {
                var result = rentalMethod.GetPropertyById(PropertyId);
                if(result!=null)
                {
                    responsess.Status = true;
                    responsess.Message = "Get Successfully";
                    responsess.Data = result;
                }
                else

                {
                    responsess.Status = false;
                    responsess.Message = "Not Get";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsess));
            return response;
        }

        [HttpPut]
        [Route("api/UpdateProperty/{PropertyId}")]
        public HttpResponseMessage UpdateProperty(int PropertyId,UpdatePostModel updatePostModel)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response<UpdatePostModel> responsess = new Response<UpdatePostModel>();
            try
            {
                var result = rentalMethod.UpdateProperty(PropertyId, updatePostModel);
                if(result==true)
                {
                    responsess.Status = true;
                    responsess.Message = "Update Successfully...!";
                }
                else
                {
                    responsess.Status = false;
                    responsess.Message = "Update Unuccessfull...!";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            response = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsess));
            return response;
        }


        //Send Request Controller

        [HttpPost]
        [Route("api/SendRequest")]
        public HttpResponseMessage SendRequest(SendRequestModel sendRequestModel)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            Response<SendRequestModel> responsess = new Response<SendRequestModel>();
            try
            {
                var result=rentalMethod.SendRequest(sendRequestModel);
                if(result!=null)
                {
                    responsess.Status=true;
                    responsess.Data=result;
                    responsess.Message = "Request Send Successfully...!";
                  
                }
                else
                {
                    responsess.Status = false;
                    responsess.Message = "Request Failed";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(responsess));
            return httpResponseMessage;
        }


        //get Request controller
        [HttpGet]
        [Route("api/GetRequest/{PropertyId}")]
        public HttpResponseMessage GetRequest(int PropertyId)
        {
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            Response<List<GetBuyerRequestResoponseModel>> obj = new Response<List<GetBuyerRequestResoponseModel>>();
            try
            {
                var result=rentalMethod.GetRequest(PropertyId);
                if(result!=null)
                {
                    obj.Status=true;
                    obj.Data = result;
                    obj.Message = "Response Get Successfully...!"; 
                }
                else
                {
                    obj.Status = false;
                    obj.Message = "Not Found";
                }
                httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, JObject.FromObject(obj));
                return httpResponseMessage;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }






    }
}