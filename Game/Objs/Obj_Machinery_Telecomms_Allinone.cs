// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms_Allinone : Obj_Machinery_Telecomms {

		public bool intercept = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.use_power = 0;
			this.machinetype = 6;
			this.icon_state = "comm_server";
		}

		public Obj_Machinery_Telecomms_Allinone ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: allinone.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Device_Multitool ) {
				this.attack_hand( user );
			}
			return null;
		}

		// Function from file: allinone.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			dynamic original = null;

			
			if ( !this.on ) {
				return false;
			}

			if ( this.is_freq_listening( signal ) ) {
				signal.data["done"] = 1;
				signal.data["compression"] = 0;
				original = signal.data["original"];

				if ( Lang13.Bool( original ) ) {
					original.data["done"] = 1;
				}

				if ( Convert.ToDouble( signal.data["slow"] ) > 0 ) {
					Task13.Sleep( Convert.ToInt32( signal.data["slow"] ) );
				}

				if ( signal.frequency == GlobalVars.SYND_FREQ ) {
					GlobalFuncs.Broadcast_Message( signal.data["mob"], Lang13.Bool( signal.data["vmask"] ), signal.data["radio"], signal.data["message"], signal.data["name"], signal.data["job"], signal.data["realname"], null, Lang13.Bool( signal.data["compression"] ), new ByTable(new object [] { 0, this.z }), signal.frequency, signal.data["spans"], signal.data["verb_say"], signal.data["verb_ask"], signal.data["verb_exclaim"], signal.data["verb_yell"] );
				}
			}
			return false;
		}

	}

}