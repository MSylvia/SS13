// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Automation_SetScrubberMode : Automation {

		public dynamic scrubber = null;
		public double? mode = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Scrubber: Mode";
		}

		// Function from file: scrubbers.dm
		public Automation_SetScrubberMode ( Obj_Machinery_Computer_GeneralAirControl_AtmosAutomation aa = null ) : base( aa ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.children = new ByTable(new object [] { null });
			return;
		}

		// Function from file: scrubbers.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic _default = null;

			ByTable injector_names = null;
			Obj_Machinery_Atmospherics_Unary_VentScrubber S = null;

			_default = base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( Lang13.Bool( href_list["set_mode"] ) ) {
				this.mode = !Lang13.Bool( this.mode ) ?1:0;
				this.parent.updateUsrDialog();
				return 1;
			}

			if ( Lang13.Bool( href_list["set_scrubber"] ) ) {
				injector_names = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.atmos_machines, typeof(Obj_Machinery_Atmospherics_Unary_VentScrubber) )) {
					S = _a;
					

					if ( !( S.id_tag == null ) && S.frequency == this.parent.frequency ) {
						injector_names.Or( S.id_tag );
					}
				}
				this.scrubber = Interface13.Input( "Select a scrubber:", "Scrubbers", this.scrubber, null, injector_names, InputType.Null | InputType.Any );
				this.parent.updateUsrDialog();
				return 1;
			}
			return _default;
		}

		// Function from file: scrubbers.dm
		public override string GetText(  ) {
			return new Txt( "Set Scrubber <a href=\"?src=" ).Ref( this ).str( ";set_scrubber=1\">" ).item( this.fmtString( this.scrubber ) ).str( "</a> mode to <a href=\"?src=" ).Ref( this ).str( ";set_mode=1\">" ).item( ( Lang13.Bool( this.mode ) ? "Scrubbing" : "Syphoning" ) ).str( "</a>." ).ToString();
		}

		// Function from file: scrubbers.dm
		public override bool process(  ) {
			
			if ( Lang13.Bool( this.scrubber ) ) {
				this.parent.send_signal( new ByTable().Set( "tag", this.scrubber ).Set( "sigtype", "command" ).Set( "scrubbing", this.mode ), GlobalVars.RADIO_FROM_AIRALARM );
			}
			return false;
		}

		// Function from file: scrubbers.dm
		public override void Import( ByTable json = null ) {
			base.Import( json );
			this.scrubber = json["scrubber"];
			this.mode = String13.ParseNumber( json["mode"] );
			return;
		}

		// Function from file: scrubbers.dm
		public override ByTable Export(  ) {
			ByTable json = null;

			json = base.Export();
			json["scrubber"] = this.scrubber;
			json["mode"] = this.mode;
			return json;
		}

	}

}