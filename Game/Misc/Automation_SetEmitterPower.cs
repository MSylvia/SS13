// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Automation_SetEmitterPower : Automation {

		public dynamic emitter = null;
		public double? on = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Emitter: Set Power";
		}

		public Automation_SetEmitterPower ( Obj_Machinery_Computer_GeneralAirControl_AtmosAutomation aa = null ) : base( aa ) {
			
		}

		// Function from file: emitters.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			dynamic _default = null;

			ByTable emitters = null;
			Obj_Machinery_Power_Emitter E = null;

			_default = base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( Lang13.Bool( href_list["set_power"] ) ) {
				this.on = !Lang13.Bool( this.on ) ?1:0;
				this.parent.updateUsrDialog();
				return 1;
			}

			if ( Lang13.Bool( href_list["set_subject"] ) ) {
				emitters = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.power_machines, typeof(Obj_Machinery_Power_Emitter) )) {
					E = _a;
					

					if ( !( E.id_tag == null ) && E.frequency == this.parent.frequency ) {
						emitters.Or( E.id_tag );
					}
				}

				if ( emitters.len == 0 ) {
					GlobalFuncs.to_chat( Task13.User, "<span class='warning'>Unable to find any emitters on this frequency.</span>" );
					return _default;
				}
				this.emitter = Interface13.Input( "Select an emitter:", "Emitter", this.emitter, null, emitters, InputType.Null | InputType.Any );
				this.parent.updateUsrDialog();
				return 1;
			}
			return _default;
		}

		// Function from file: emitters.dm
		public override string GetText(  ) {
			return new Txt( "Set emitter <a href=\"?src=" ).Ref( this ).str( ";set_subject=1\">" ).item( this.fmtString( this.emitter ) ).str( "</a> to <a href=\"?src=" ).Ref( this ).str( ";set_power=1\">" ).item( ( Lang13.Bool( this.on ) ? "on" : "off" ) ).str( "</a>." ).ToString();
		}

		// Function from file: emitters.dm
		public override bool process(  ) {
			
			if ( Lang13.Bool( this.emitter ) ) {
				this.parent.send_signal( new ByTable().Set( "tag", this.emitter ).Set( "command", "set" ).Set( "state", this.on ) );
			}
			return false;
		}

		// Function from file: emitters.dm
		public override void Import( ByTable json = null ) {
			base.Import( json );
			this.emitter = json["emitter"];
			this.on = String13.ParseNumber( json["on"] );
			return;
		}

		// Function from file: emitters.dm
		public override ByTable Export(  ) {
			ByTable json = null;

			json = base.Export();
			json["emitter"] = this.emitter;
			json["on"] = this.on;
			return json;
		}

	}

}