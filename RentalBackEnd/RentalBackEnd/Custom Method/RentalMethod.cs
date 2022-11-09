using Amazon.Runtime.Internal;
using Microsoft.AspNetCore.Http;
using RentalBackEnd.Custom_Model;
using RentalBackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using HttpContext = Microsoft.AspNetCore.Http.HttpContext;
using HttpRequest = Microsoft.AspNetCore.Http.HttpRequest;

namespace RentalBackEnd.Custom_Method
{
    public class RentalMethod
    {
        LandlordDataContext landlordDataContext;

        public RentalMethod()
        {
            landlordDataContext = new LandlordDataContext();
        }

        public LandlordPostModel AddLandLord(LandlordPostModel landlordPostModel)
        {
            try
            {
                if (landlordPostModel.Password == landlordPostModel.ConfirmPassword)
                {
                    landlordDataContext._spLandlordRegistration(landlordPostModel.UserName, landlordPostModel.Password, landlordPostModel.Email, landlordPostModel.Number, landlordPostModel.Address, landlordPostModel.Image);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return landlordPostModel;
        }

        public LandlordLogin AddLandlordLogin(LandlordLogin landlordLogin)
        {
            LandlordLogin loginResponseModel = new LandlordLogin();
            try
            {
                var login = landlordDataContext._spLandLordLogin(landlordLogin.Email, landlordLogin.Password).FirstOrDefault();
                if (login != null)
                {
                    loginResponseModel.Email = login.Email;
                    loginResponseModel.Password = login.Password;
                    loginResponseModel.RentarId=login.RentarId;
                    loginResponseModel.UserName=login.UserName;
                    return loginResponseModel;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }
           //return landlordLogin;
          }


        public AddPropertyPostModel AddProperty(AddPropertyPostModel addPropertyPostModel)
        {
            try
            {
            
                landlordDataContext._spAddProperty(addPropertyPostModel.PropertyName, addPropertyPostModel.SqureFeet, addPropertyPostModel.RentalCost, addPropertyPostModel.City, addPropertyPostModel.Location, addPropertyPostModel.Type, addPropertyPostModel.LandLordName, addPropertyPostModel.PropertyImage,addPropertyPostModel.RentarId);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return addPropertyPostModel;
        }



        public List<PropertyResponseModel> GetAllProperty(int RentarId)
        {
            List<PropertyResponseModel> getallresponse=new List<PropertyResponseModel>();
            try
            {

                var response = landlordDataContext._spPropertyResponse(RentarId).ToList();
                getallresponse = response.Select(x => new PropertyResponseModel
                {
                    RentalCost= (decimal)x.RentalCost,
                    Location = x.Location,
                    Type = x.Type,
                    PropertyName=x.PropertyName,
                    SqureFeet = x.SqureFeet,
                    City = x.City,
                    LandLordName = x.LandLordName,
                   PropertyImage = x.PropertyImage,
                   ProperyId=x.PropertyId,
                   RentarId= (int)x.RentarId
             
                }).ToList();

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return getallresponse;
        }



        public List<PropertyResponseModel> getMyProperties(int RentarId)
        {
            List<PropertyResponseModel> getallresponse = new List<PropertyResponseModel>();
            try
            {

                var response = landlordDataContext._spgetMyProperties(RentarId).ToList();
                getallresponse = response.Select(x => new PropertyResponseModel
                {
                    RentalCost = (decimal)x.RentalCost,
                    Location = x.Location,
                    Type = x.Type,
                    PropertyName = x.PropertyName,
                    SqureFeet = x.SqureFeet,
                    City = x.City,
                    LandLordName = x.LandLordName,
                    PropertyImage = x.PropertyImage,
                    ProperyId = x.PropertyId,
                    RentarId = (int)x.RentarId

                }).ToList();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return getallresponse;
        }


        public bool DeleteProperty(int PropertyId)
        {
            try
            {
                var delete = landlordDataContext._spDeletePropery(PropertyId);
                if(delete!=null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public PropertyResponseModel GetPropertyById(int PropertyId)
        {
            PropertyResponseModel propertyResponseModel = new PropertyResponseModel();
            try
            {
                var getproperty = landlordDataContext._spGetPropertyById(PropertyId).FirstOrDefault();
                propertyResponseModel.RentarId = (int)getproperty.RentarId;
                propertyResponseModel.LandLordName=getproperty.LandLordName;
                propertyResponseModel.Location=getproperty.Location;
                propertyResponseModel.City=getproperty.City;
                propertyResponseModel.SqureFeet = getproperty.SqureFeet;
                propertyResponseModel.RentalCost = (decimal)getproperty.RentalCost;
                propertyResponseModel.ProperyId = getproperty.PropertyId;
                propertyResponseModel.PropertyName = getproperty.PropertyName;
                propertyResponseModel.PropertyImage=getproperty.PropertyImage;
                propertyResponseModel.Type = getproperty.Type;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return propertyResponseModel;
        }

        public bool UpdateProperty(int PropertyId, UpdatePostModel updatePostModel)
        {
            try
            {
                var result = landlordDataContext._spUpdateProperty(updatePostModel.PropertyName, updatePostModel.SquareFeet, updatePostModel.RentalCost, updatePostModel.City, updatePostModel.Location, updatePostModel.Type,updatePostModel.LandLordName,updatePostModel.PropertyImage,PropertyId);
                    if(result!=null)
                {
                    return true;
                }
                    else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    

        //Send Request
        public SendRequestModel SendRequest(SendRequestModel sendRequestModel)
        {
            try
            {
                var result = landlordDataContext._spBuyerTable(sendRequestModel.BuyerId, sendRequestModel.SellerId, sendRequestModel.PropertyId, sendRequestModel.LandLordName, sendRequestModel.RentAmount, sendRequestModel.SecurityDeposit);
                if(result!=null)
                {
                    return sendRequestModel;
                }
                else
                {
                    return null;
                }

             }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        //Get Request 

        public List<GetBuyerRequestResoponseModel> GetRequest(int PropertyId)
        {
            List<GetBuyerRequestResoponseModel> getallreqest = new List<GetBuyerRequestResoponseModel>();
            try
            {
                var result = landlordDataContext._spGetShowRequest(PropertyId).ToList();
                getallreqest = result.Select(x => new GetBuyerRequestResoponseModel
                {
                    Address = x.Address,
                    BuyerdImage = x.Image,
                    BuyerEmail = x.Email,
                    BuyerMobile = x.Number,
                    BuyerName = x.Username,
                    RentAmount = (decimal)x.RentAmount,
                    SecurityDeposit = (decimal)x.SecurityDeposit,
                }).ToList();
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return getallreqest;
            
        }


    }
    }
