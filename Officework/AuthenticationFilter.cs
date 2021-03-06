﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;

namespace Officework
{
	public class AuthenticationFilter : System.Web.Http.Filters.ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.Request.Headers.Authorization == null)
			{
				actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
			}
			else
			{
				string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
				string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
				string userName = decodedToken.Substring(0, decodedToken.IndexOf(":"));
				string userPassword = decodedToken.Substring(decodedToken.IndexOf(":"));
				if(userName== "Deepanshu" && userPassword== "test")
				{
					//authorized
				}
				else
				{
					actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
				}

			}
		}
	}
}