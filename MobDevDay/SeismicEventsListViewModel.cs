﻿//
// SeismicEventsListViewModel.cs
//
// Author:
//       Stephane Delcroix <stephane@mi8.be>
//
// Copyright (c) 2013 mobile inception
//
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Net.Http;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobDevDay
{
	public class SeismicEvent 
	{
		public string Title {get;set;}
		public string Longitude { get; set; }
		public string Latitude { get; set; }
		public DateTime Date { get; set; }
	}

	public class SeismicEventsListViewModel : INotifyPropertyChanged
	{
		string url = "http://seismologie.oma.be/rss/rss.php?LANG=FR&CNT=BE";

		bool isBusy;
		public bool IsBusy {
			get {return isBusy; }
			set {
 				if (isBusy == value)
					return;
				isBusy = value;
				OnPropertyChanged ();
			}
		}

		IList<SeismicEvent> events;
		public IList<SeismicEvent> Events {
			get {return events; }
			private set { 
 				if (events == value)
					return;
				events = value;
				OnPropertyChanged ();
			}
		}
			
		public ICommand RefreshCommand { get { return new Command (Refresh); }}
		void Refresh ()
		{
			XNamespace geo = "http://www.w3.org/2003/01/geo/wgs84_pos#";
			if (IsBusy)
				return;
			IsBusy = true;

			var client = new HttpClient ();
			var response = client.GetStringAsync (new Uri (url)).Result;

			var document = XDocument.Parse (response);
			var eventlist = from item in document.Descendants ("item")
			             select new SeismicEvent () { 
				Title = item.Element("title").Value,
				Latitude = item.Element(geo + "lat").Value,
				Longitude = item.Element(geo + "long").Value,
				Date = DateTime.Parse (item.Element("pubDate").Value),
			};

			Events = eventlist.ToList ();
			IsBusy = false;
		}
			
		void OnPropertyChanged ([CallerMemberName] string propertyName = null)
		{
			var eh = PropertyChanged;
			if (eh != null)
				eh (this, new PropertyChangedEventArgs (propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}