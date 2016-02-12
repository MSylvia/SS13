// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Media_Receiver : Obj_Machinery_Media {

		public dynamic media_frequency = 1234;
		public dynamic media_crypto = null;

		// Function from file: receiver.dm
		public Obj_Machinery_Media_Receiver ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.connect_frequency();
			return;
		}

		// Function from file: receiver.dm
		public void disconnect_frequency(  ) {
			ByTable receivers = null;
			string freq = null;

			receivers = new ByTable();
			freq = String13.NumberToString( Convert.ToDouble( this.media_frequency ) );

			if ( GlobalVars.media_receivers.Contains( freq ) ) {
				receivers = GlobalVars.media_receivers[freq];
			}
			receivers.Remove( this );
			GlobalVars.media_receivers[freq] = receivers;
			this.receive_broadcast();
			return;
		}

		// Function from file: receiver.dm
		public void connect_frequency(  ) {
			ByTable receivers = null;
			string freq = null;
			dynamic B = null;

			receivers = new ByTable();
			freq = String13.NumberToString( Convert.ToDouble( this.media_frequency ) );

			if ( GlobalVars.media_receivers.Contains( freq ) ) {
				receivers = GlobalVars.media_receivers[freq];
			}
			receivers.Add( this );
			GlobalVars.media_receivers[freq] = receivers;

			if ( GlobalVars.media_transmitters.Contains( freq ) ) {
				B = Rand13.PickFromTable( GlobalVars.media_transmitters[freq] );

				if ( B.media_crypto == this.media_crypto ) {
					this.receive_broadcast( B.media_url, B.media_start_time );
				}
			}
			return;
		}

		// Function from file: receiver.dm
		public void receive_broadcast( string url = null, int? start_time = null ) {
			url = url ?? "";
			start_time = start_time ?? 0;

			this.media_url = url;
			this.media_start_time = start_time;
			this.update_music();
			return;
		}

	}

}