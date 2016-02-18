// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_MeteorWave : RoundEvent {

		public ByTable wave_type = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.startWhen = 6;
			this.endWhen = 66;
			this.announceWhen = 1;
		}

		// Function from file: meteor_wave.dm
		public RoundEvent_MeteorWave (  ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.random_wave_type();
			return;
		}

		// Function from file: meteor_wave.dm
		public override void tick(  ) {
			
			if ( GlobalFuncs.IsMultiple( this.activeFor, 3 ) ) {
				GlobalFuncs.spawn_meteors( 5, this.wave_type );
			}
			return;
		}

		// Function from file: meteor_wave.dm
		public override void announce(  ) {
			GlobalFuncs.priority_announce( "Meteors have been detected on collision course with the station.", "Meteor Alert", "sound/AI/meteors.ogg" );
			return;
		}

		// Function from file: meteor_wave.dm
		public void random_wave_type(  ) {
			dynamic picked_wave = null;

			picked_wave = GlobalFuncs.pickweight( new ByTable().Set( "normal", 50 ).Set( "threatening", 40 ).Set( "catastrophic", 10 ) );

			dynamic _a = picked_wave; // Was a switch-case, sorry for the mess.
			if ( _a=="normal" ) {
				this.wave_type = GlobalVars.meteors_normal;
			} else if ( _a=="threatening" ) {
				this.wave_type = GlobalVars.meteors_threatening;
			} else if ( _a=="catastrophic" ) {
				this.wave_type = GlobalVars.meteors_catastrophic;
			}
			return;
		}

	}

}