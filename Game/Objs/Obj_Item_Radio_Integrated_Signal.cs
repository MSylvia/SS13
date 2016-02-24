// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Radio_Integrated_Signal : Obj_Item_Radio_Integrated {

		public double frequency = 1457;
		public double code = 30;
		public int last_transmission = 0;
		public RadioFrequency radio_connection = null;

		// Function from file: radio.dm
		public Obj_Item_Radio_Integrated_Signal ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( GlobalVars.SSradio != null ) {
				this.initialize();
			}
			return;
		}

		// Function from file: tgstation.dme
		public void send_signal( string message = null ) {
			message = message ?? "ACTIVATE";

			string time = null;
			dynamic T = null;
			Signal signal = null;

			
			if ( this.last_transmission != 0 && Game13.time < this.last_transmission + 5 ) {
				return;
			}
			this.last_transmission = Game13.time;
			time = String13.FormatTime( Game13.realtime, "hh:mm:ss" );
			T = GlobalFuncs.get_turf( this );
			GlobalVars.lastsignalers.Add( "" + time + " <B>:</B> " + Task13.User.key + " used " + this + " @ location (" + T.x + "," + T.y + "," + T.z + ") <B>:</B> " + GlobalFuncs.format_frequency( this.frequency ) + "/" + this.code );
			signal = new Signal();
			signal.source = this;
			signal.encryption = this.code;
			signal.data["message"] = message;
			this.radio_connection.post_signal( this, signal );
			return;
		}

		// Function from file: radio.dm
		public void set_frequency( double new_frequency = 0 ) {
			GlobalVars.SSradio.remove_object( this, this.frequency );
			this.frequency = new_frequency;
			this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency );
			return;
		}

		// Function from file: radio.dm
		public override void initialize(  ) {
			
			if ( this.frequency < 1200 || this.frequency > 1600 ) {
				this.frequency = GlobalFuncs.sanitize_frequency( this.frequency );
			}
			this.set_frequency( this.frequency );
			return;
		}

		// Function from file: radio.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			return base.Destroy();
		}

	}

}