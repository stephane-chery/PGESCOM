﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PGESCOM
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Orig_PSM_FDB")]
	public partial class DC_PGCdbDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertHK_Overages_Sale(HK_Overages_Sale instance);
    partial void UpdateHK_Overages_Sale(HK_Overages_Sale instance);
    partial void DeleteHK_Overages_Sale(HK_Overages_Sale instance);
    #endregion
		
		public DC_PGCdbDataContext() : 
				base(global::PGESCOM.Properties.Settings.Default.Orig_PSM_FDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DC_PGCdbDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DC_PGCdbDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DC_PGCdbDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DC_PGCdbDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<HK_Overages_Sale> HK_Overages_Sales
		{
			get
			{
				return this.GetTable<HK_Overages_Sale>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HK_Overages_Sales")]
	public partial class HK_Overages_Sale : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _LID;
		
		private System.Nullable<int> _YY_fscl;
		
		private System.Nullable<int> _MM_fscl;
		
		private System.Nullable<long> _QuoteID;
		
		private System.Nullable<System.DateTime> _DateLastInvPrt;
		
		private System.Nullable<int> _RID;
		
		private string _CustomerID;
		
		private string _InvID;
		
		private string _Currncy;
		
		private string _SO;
		
		private System.Nullable<int> _SOLine;
		
		private string _STKCode;
		
		private string _UserDef;
		
		private string _Salesperson;
		
		private string _IntSalesperson;
		
		private System.Nullable<decimal> _Old_Overage;
		
		private System.Nullable<decimal> _Old_Overage_CAD;
		
		private System.Nullable<decimal> _New_Overage;
		
		private System.Nullable<decimal> _New_Overage_CAD;
		
		private System.Nullable<decimal> _PRIMAX_OLD;
		
		private System.Nullable<decimal> _PRIMAX;
		
		private System.Nullable<decimal> _Mona_Dimassi_OLD;
		
		private System.Nullable<decimal> _Mona_Dimassi;
		
		private System.Nullable<decimal> _Claude_Fouche_OLD;
		
		private System.Nullable<decimal> _Claude_Fouche;
		
		private System.Nullable<decimal> _Benoit_Cimon_OLD;
		
		private System.Nullable<decimal> _Benoit_Cimon;
		
		private System.Nullable<decimal> _Yves_Lavoie_OLD;
		
		private System.Nullable<decimal> _Yves_Lavoie;
		
		private System.Nullable<decimal> _Steven_Monk_OLD;
		
		private System.Nullable<decimal> _Steven_Monk;
		
		private string _Cmnt;
		
		private System.Nullable<decimal> _Xrate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnLIDChanging(long value);
    partial void OnLIDChanged();
    partial void OnYY_fsclChanging(System.Nullable<int> value);
    partial void OnYY_fsclChanged();
    partial void OnMM_fsclChanging(System.Nullable<int> value);
    partial void OnMM_fsclChanged();
    partial void OnQuoteIDChanging(System.Nullable<long> value);
    partial void OnQuoteIDChanged();
    partial void OnDateLastInvPrtChanging(System.Nullable<System.DateTime> value);
    partial void OnDateLastInvPrtChanged();
    partial void OnRIDChanging(System.Nullable<int> value);
    partial void OnRIDChanged();
    partial void OnCustomerIDChanging(string value);
    partial void OnCustomerIDChanged();
    partial void OnInvIDChanging(string value);
    partial void OnInvIDChanged();
    partial void OnCurrncyChanging(string value);
    partial void OnCurrncyChanged();
    partial void OnSOChanging(string value);
    partial void OnSOChanged();
    partial void OnSOLineChanging(System.Nullable<int> value);
    partial void OnSOLineChanged();
    partial void OnSTKCodeChanging(string value);
    partial void OnSTKCodeChanged();
    partial void OnUserDefChanging(string value);
    partial void OnUserDefChanged();
    partial void OnSalespersonChanging(string value);
    partial void OnSalespersonChanged();
    partial void OnIntSalespersonChanging(string value);
    partial void OnIntSalespersonChanged();
    partial void OnOld_OverageChanging(System.Nullable<decimal> value);
    partial void OnOld_OverageChanged();
    partial void OnOld_Overage_CADChanging(System.Nullable<decimal> value);
    partial void OnOld_Overage_CADChanged();
    partial void OnNew_OverageChanging(System.Nullable<decimal> value);
    partial void OnNew_OverageChanged();
    partial void OnNew_Overage_CADChanging(System.Nullable<decimal> value);
    partial void OnNew_Overage_CADChanged();
    partial void OnPRIMAX_OLDChanging(System.Nullable<decimal> value);
    partial void OnPRIMAX_OLDChanged();
    partial void OnPRIMAXChanging(System.Nullable<decimal> value);
    partial void OnPRIMAXChanged();
    partial void OnMona_Dimassi_OLDChanging(System.Nullable<decimal> value);
    partial void OnMona_Dimassi_OLDChanged();
    partial void OnMona_DimassiChanging(System.Nullable<decimal> value);
    partial void OnMona_DimassiChanged();
    partial void OnClaude_Fouche_OLDChanging(System.Nullable<decimal> value);
    partial void OnClaude_Fouche_OLDChanged();
    partial void OnClaude_FoucheChanging(System.Nullable<decimal> value);
    partial void OnClaude_FoucheChanged();
    partial void OnBenoit_Cimon_OLDChanging(System.Nullable<decimal> value);
    partial void OnBenoit_Cimon_OLDChanged();
    partial void OnBenoit_CimonChanging(System.Nullable<decimal> value);
    partial void OnBenoit_CimonChanged();
    partial void OnYves_Lavoie_OLDChanging(System.Nullable<decimal> value);
    partial void OnYves_Lavoie_OLDChanged();
    partial void OnYves_LavoieChanging(System.Nullable<decimal> value);
    partial void OnYves_LavoieChanged();
    partial void OnSteven_Monk_OLDChanging(System.Nullable<decimal> value);
    partial void OnSteven_Monk_OLDChanged();
    partial void OnSteven_MonkChanging(System.Nullable<decimal> value);
    partial void OnSteven_MonkChanged();
    partial void OnCmntChanging(string value);
    partial void OnCmntChanged();
    partial void OnXrateChanging(System.Nullable<decimal> value);
    partial void OnXrateChanged();
    #endregion
		
		public HK_Overages_Sale()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LID", AutoSync=AutoSync.OnInsert, DbType="BigInt NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public long LID
		{
			get
			{
				return this._LID;
			}
			set
			{
				if ((this._LID != value))
				{
					this.OnLIDChanging(value);
					this.SendPropertyChanging();
					this._LID = value;
					this.SendPropertyChanged("LID");
					this.OnLIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YY_fscl", DbType="Int")]
		public System.Nullable<int> YY_fscl
		{
			get
			{
				return this._YY_fscl;
			}
			set
			{
				if ((this._YY_fscl != value))
				{
					this.OnYY_fsclChanging(value);
					this.SendPropertyChanging();
					this._YY_fscl = value;
					this.SendPropertyChanged("YY_fscl");
					this.OnYY_fsclChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MM_fscl", DbType="Int")]
		public System.Nullable<int> MM_fscl
		{
			get
			{
				return this._MM_fscl;
			}
			set
			{
				if ((this._MM_fscl != value))
				{
					this.OnMM_fsclChanging(value);
					this.SendPropertyChanging();
					this._MM_fscl = value;
					this.SendPropertyChanged("MM_fscl");
					this.OnMM_fsclChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuoteID", DbType="BigInt")]
		public System.Nullable<long> QuoteID
		{
			get
			{
				return this._QuoteID;
			}
			set
			{
				if ((this._QuoteID != value))
				{
					this.OnQuoteIDChanging(value);
					this.SendPropertyChanging();
					this._QuoteID = value;
					this.SendPropertyChanged("QuoteID");
					this.OnQuoteIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateLastInvPrt", DbType="DateTime")]
		public System.Nullable<System.DateTime> DateLastInvPrt
		{
			get
			{
				return this._DateLastInvPrt;
			}
			set
			{
				if ((this._DateLastInvPrt != value))
				{
					this.OnDateLastInvPrtChanging(value);
					this.SendPropertyChanging();
					this._DateLastInvPrt = value;
					this.SendPropertyChanged("DateLastInvPrt");
					this.OnDateLastInvPrtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RID", DbType="Int")]
		public System.Nullable<int> RID
		{
			get
			{
				return this._RID;
			}
			set
			{
				if ((this._RID != value))
				{
					this.OnRIDChanging(value);
					this.SendPropertyChanging();
					this._RID = value;
					this.SendPropertyChanged("RID");
					this.OnRIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CustomerID", DbType="NVarChar(255)")]
		public string CustomerID
		{
			get
			{
				return this._CustomerID;
			}
			set
			{
				if ((this._CustomerID != value))
				{
					this.OnCustomerIDChanging(value);
					this.SendPropertyChanging();
					this._CustomerID = value;
					this.SendPropertyChanged("CustomerID");
					this.OnCustomerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_InvID", DbType="NVarChar(50)")]
		public string InvID
		{
			get
			{
				return this._InvID;
			}
			set
			{
				if ((this._InvID != value))
				{
					this.OnInvIDChanging(value);
					this.SendPropertyChanging();
					this._InvID = value;
					this.SendPropertyChanged("InvID");
					this.OnInvIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Currncy", DbType="NVarChar(10)")]
		public string Currncy
		{
			get
			{
				return this._Currncy;
			}
			set
			{
				if ((this._Currncy != value))
				{
					this.OnCurrncyChanging(value);
					this.SendPropertyChanging();
					this._Currncy = value;
					this.SendPropertyChanged("Currncy");
					this.OnCurrncyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SO", DbType="NVarChar(255)")]
		public string SO
		{
			get
			{
				return this._SO;
			}
			set
			{
				if ((this._SO != value))
				{
					this.OnSOChanging(value);
					this.SendPropertyChanging();
					this._SO = value;
					this.SendPropertyChanged("SO");
					this.OnSOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SOLine", DbType="Int")]
		public System.Nullable<int> SOLine
		{
			get
			{
				return this._SOLine;
			}
			set
			{
				if ((this._SOLine != value))
				{
					this.OnSOLineChanging(value);
					this.SendPropertyChanging();
					this._SOLine = value;
					this.SendPropertyChanged("SOLine");
					this.OnSOLineChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_STKCode", DbType="NVarChar(255)")]
		public string STKCode
		{
			get
			{
				return this._STKCode;
			}
			set
			{
				if ((this._STKCode != value))
				{
					this.OnSTKCodeChanging(value);
					this.SendPropertyChanging();
					this._STKCode = value;
					this.SendPropertyChanged("STKCode");
					this.OnSTKCodeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserDef", DbType="NVarChar(50)")]
		public string UserDef
		{
			get
			{
				return this._UserDef;
			}
			set
			{
				if ((this._UserDef != value))
				{
					this.OnUserDefChanging(value);
					this.SendPropertyChanging();
					this._UserDef = value;
					this.SendPropertyChanged("UserDef");
					this.OnUserDefChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Salesperson", DbType="NChar(10)")]
		public string Salesperson
		{
			get
			{
				return this._Salesperson;
			}
			set
			{
				if ((this._Salesperson != value))
				{
					this.OnSalespersonChanging(value);
					this.SendPropertyChanging();
					this._Salesperson = value;
					this.SendPropertyChanged("Salesperson");
					this.OnSalespersonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IntSalesperson", DbType="NChar(10)")]
		public string IntSalesperson
		{
			get
			{
				return this._IntSalesperson;
			}
			set
			{
				if ((this._IntSalesperson != value))
				{
					this.OnIntSalespersonChanging(value);
					this.SendPropertyChanging();
					this._IntSalesperson = value;
					this.SendPropertyChanged("IntSalesperson");
					this.OnIntSalespersonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Old_Overage", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Old_Overage
		{
			get
			{
				return this._Old_Overage;
			}
			set
			{
				if ((this._Old_Overage != value))
				{
					this.OnOld_OverageChanging(value);
					this.SendPropertyChanging();
					this._Old_Overage = value;
					this.SendPropertyChanged("Old_Overage");
					this.OnOld_OverageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Old_Overage_CAD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Old_Overage_CAD
		{
			get
			{
				return this._Old_Overage_CAD;
			}
			set
			{
				if ((this._Old_Overage_CAD != value))
				{
					this.OnOld_Overage_CADChanging(value);
					this.SendPropertyChanging();
					this._Old_Overage_CAD = value;
					this.SendPropertyChanged("Old_Overage_CAD");
					this.OnOld_Overage_CADChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_New_Overage", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> New_Overage
		{
			get
			{
				return this._New_Overage;
			}
			set
			{
				if ((this._New_Overage != value))
				{
					this.OnNew_OverageChanging(value);
					this.SendPropertyChanging();
					this._New_Overage = value;
					this.SendPropertyChanged("New_Overage");
					this.OnNew_OverageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_New_Overage_CAD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> New_Overage_CAD
		{
			get
			{
				return this._New_Overage_CAD;
			}
			set
			{
				if ((this._New_Overage_CAD != value))
				{
					this.OnNew_Overage_CADChanging(value);
					this.SendPropertyChanging();
					this._New_Overage_CAD = value;
					this.SendPropertyChanged("New_Overage_CAD");
					this.OnNew_Overage_CADChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRIMAX_OLD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> PRIMAX_OLD
		{
			get
			{
				return this._PRIMAX_OLD;
			}
			set
			{
				if ((this._PRIMAX_OLD != value))
				{
					this.OnPRIMAX_OLDChanging(value);
					this.SendPropertyChanging();
					this._PRIMAX_OLD = value;
					this.SendPropertyChanged("PRIMAX_OLD");
					this.OnPRIMAX_OLDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRIMAX", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> PRIMAX
		{
			get
			{
				return this._PRIMAX;
			}
			set
			{
				if ((this._PRIMAX != value))
				{
					this.OnPRIMAXChanging(value);
					this.SendPropertyChanging();
					this._PRIMAX = value;
					this.SendPropertyChanged("PRIMAX");
					this.OnPRIMAXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Mona Dimassi OLD]", Storage="_Mona_Dimassi_OLD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Mona_Dimassi_OLD
		{
			get
			{
				return this._Mona_Dimassi_OLD;
			}
			set
			{
				if ((this._Mona_Dimassi_OLD != value))
				{
					this.OnMona_Dimassi_OLDChanging(value);
					this.SendPropertyChanging();
					this._Mona_Dimassi_OLD = value;
					this.SendPropertyChanged("Mona_Dimassi_OLD");
					this.OnMona_Dimassi_OLDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Mona Dimassi]", Storage="_Mona_Dimassi", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Mona_Dimassi
		{
			get
			{
				return this._Mona_Dimassi;
			}
			set
			{
				if ((this._Mona_Dimassi != value))
				{
					this.OnMona_DimassiChanging(value);
					this.SendPropertyChanging();
					this._Mona_Dimassi = value;
					this.SendPropertyChanged("Mona_Dimassi");
					this.OnMona_DimassiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Claude Fouche OLD]", Storage="_Claude_Fouche_OLD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Claude_Fouche_OLD
		{
			get
			{
				return this._Claude_Fouche_OLD;
			}
			set
			{
				if ((this._Claude_Fouche_OLD != value))
				{
					this.OnClaude_Fouche_OLDChanging(value);
					this.SendPropertyChanging();
					this._Claude_Fouche_OLD = value;
					this.SendPropertyChanged("Claude_Fouche_OLD");
					this.OnClaude_Fouche_OLDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Claude Fouche]", Storage="_Claude_Fouche", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Claude_Fouche
		{
			get
			{
				return this._Claude_Fouche;
			}
			set
			{
				if ((this._Claude_Fouche != value))
				{
					this.OnClaude_FoucheChanging(value);
					this.SendPropertyChanging();
					this._Claude_Fouche = value;
					this.SendPropertyChanged("Claude_Fouche");
					this.OnClaude_FoucheChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Benoit Cimon OLD]", Storage="_Benoit_Cimon_OLD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Benoit_Cimon_OLD
		{
			get
			{
				return this._Benoit_Cimon_OLD;
			}
			set
			{
				if ((this._Benoit_Cimon_OLD != value))
				{
					this.OnBenoit_Cimon_OLDChanging(value);
					this.SendPropertyChanging();
					this._Benoit_Cimon_OLD = value;
					this.SendPropertyChanged("Benoit_Cimon_OLD");
					this.OnBenoit_Cimon_OLDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Benoit Cimon]", Storage="_Benoit_Cimon", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Benoit_Cimon
		{
			get
			{
				return this._Benoit_Cimon;
			}
			set
			{
				if ((this._Benoit_Cimon != value))
				{
					this.OnBenoit_CimonChanging(value);
					this.SendPropertyChanging();
					this._Benoit_Cimon = value;
					this.SendPropertyChanged("Benoit_Cimon");
					this.OnBenoit_CimonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Yves Lavoie OLD]", Storage="_Yves_Lavoie_OLD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Yves_Lavoie_OLD
		{
			get
			{
				return this._Yves_Lavoie_OLD;
			}
			set
			{
				if ((this._Yves_Lavoie_OLD != value))
				{
					this.OnYves_Lavoie_OLDChanging(value);
					this.SendPropertyChanging();
					this._Yves_Lavoie_OLD = value;
					this.SendPropertyChanged("Yves_Lavoie_OLD");
					this.OnYves_Lavoie_OLDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Yves Lavoie]", Storage="_Yves_Lavoie", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Yves_Lavoie
		{
			get
			{
				return this._Yves_Lavoie;
			}
			set
			{
				if ((this._Yves_Lavoie != value))
				{
					this.OnYves_LavoieChanging(value);
					this.SendPropertyChanging();
					this._Yves_Lavoie = value;
					this.SendPropertyChanged("Yves_Lavoie");
					this.OnYves_LavoieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Steven Monk OLD]", Storage="_Steven_Monk_OLD", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Steven_Monk_OLD
		{
			get
			{
				return this._Steven_Monk_OLD;
			}
			set
			{
				if ((this._Steven_Monk_OLD != value))
				{
					this.OnSteven_Monk_OLDChanging(value);
					this.SendPropertyChanging();
					this._Steven_Monk_OLD = value;
					this.SendPropertyChanged("Steven_Monk_OLD");
					this.OnSteven_Monk_OLDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Steven Monk]", Storage="_Steven_Monk", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Steven_Monk
		{
			get
			{
				return this._Steven_Monk;
			}
			set
			{
				if ((this._Steven_Monk != value))
				{
					this.OnSteven_MonkChanging(value);
					this.SendPropertyChanging();
					this._Steven_Monk = value;
					this.SendPropertyChanged("Steven_Monk");
					this.OnSteven_MonkChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Cmnt", DbType="NVarChar(555)")]
		public string Cmnt
		{
			get
			{
				return this._Cmnt;
			}
			set
			{
				if ((this._Cmnt != value))
				{
					this.OnCmntChanging(value);
					this.SendPropertyChanging();
					this._Cmnt = value;
					this.SendPropertyChanged("Cmnt");
					this.OnCmntChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Xrate", DbType="Decimal(18,0)")]
		public System.Nullable<decimal> Xrate
		{
			get
			{
				return this._Xrate;
			}
			set
			{
				if ((this._Xrate != value))
				{
					this.OnXrateChanging(value);
					this.SendPropertyChanging();
					this._Xrate = value;
					this.SendPropertyChanged("Xrate");
					this.OnXrateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
