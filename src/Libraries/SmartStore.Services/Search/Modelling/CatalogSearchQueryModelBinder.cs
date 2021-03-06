﻿using System;
using System.Web.Mvc;
using Autofac.Integration.Mvc;

namespace SmartStore.Services.Search.Modelling
{
	[ModelBinderType(typeof(CatalogSearchQuery))]
	public class CatalogSearchQueryModelBinder : IModelBinder
	{
		private readonly ICatalogSearchQueryFactory _factory;

		public CatalogSearchQueryModelBinder(ICatalogSearchQueryFactory factory)
		{
			_factory = factory;
		}

		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			if (_factory.Current != null)
			{
				return _factory.Current;
			}
			
			var modelType = bindingContext.ModelType;

			if (modelType != typeof(CatalogSearchQuery))
			{
				return new CatalogSearchQuery();
			}

			var query = _factory.CreateFromQuery();

			return query;

		}
	}
}
