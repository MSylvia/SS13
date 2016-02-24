// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_TeslaCoil : Obj_Machinery_Power {

		public int power_loss = 2;
		public double input_power_multiplier = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/tesla_engine/tesla_coil.dmi";
			this.icon_state = "coil";
		}

		// Function from file: coil.dm
		public Obj_Machinery_Power_TeslaCoil ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable();
			this.component_parts.Add( new Obj_Item_Weapon_Circuitboard_TeslaCoil( null ) );
			this.component_parts.Add( new Obj_Item_Weapon_StockParts_Capacitor( null ) );
			this.RefreshParts();
			return;
		}

		// Function from file: coil.dm
		public override void tesla_act( double power = 0 ) {
			double power_produced = 0;

			this.being_shocked = true;
			power_produced = power / this.power_loss;
			this.add_avail( power_produced * this.input_power_multiplier );
			Icon13.Flick( "coilhit", this );
			GlobalFuncs.playsound( this.loc, "sound/magic/LightningShock.ogg", 100, 1, 5 );
			GlobalFuncs.tesla_zap( this, 5, power_produced );
			GlobalFuncs.addtimer( this, "reset_shocked", 10 );
			return;
		}

		// Function from file: coil.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( this.default_deconstruction_screwdriver( user, "coil", "coil", A ) ) {
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( this.default_pry_open( A ) ) {
				return null;
			}

			if ( this.default_unfasten_wrench( user, A ) ) {
				
				if ( !Lang13.Bool( this.anchored ) ) {
					this.disconnect_from_network();
				} else {
					this.connect_to_network();
				}
				return null;
			}
			this.default_deconstruction_crowbar( A );
			return null;
		}

		// Function from file: coil.dm
		public override void RefreshParts(  ) {
			double power_multiplier = 0;
			Obj_Item_Weapon_StockParts_Capacitor C = null;

			power_multiplier = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts_Capacitor) )) {
				C = _a;
				
				power_multiplier += Convert.ToDouble( C.rating );
			}
			this.input_power_multiplier = power_multiplier;
			return;
		}

	}

}