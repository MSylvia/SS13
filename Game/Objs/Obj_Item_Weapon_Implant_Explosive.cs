// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implant_Explosive : Obj_Item_Weapon_Implant {

		public double weak = 2;
		public double medium = 0.8;
		public double heavy = 0.4;
		public double delay = 7;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=2;combat=3;biotech=4;syndicate=4";
			this.icon_state = "explosive";
		}

		public Obj_Item_Weapon_Implant_Explosive ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: implant_explosive.dm
		public void timed_explosion(  ) {
			((Ent_Static)this.imp_in).visible_message( "<span class = 'warning'>" + this.imp_in + " starts beeping ominously!</span>" );
			GlobalFuncs.playsound( this.loc, "sound/items/timer.ogg", 30, 0 );
			Task13.Sleep( ((int)( this.delay / 4 )) );

			if ( Lang13.Bool( this.imp_in ) && Lang13.Bool( this.imp_in.stat ) ) {
				((Ent_Static)this.imp_in).visible_message( "<span class = 'warning'>" + this.imp_in + " doubles over in pain!</span>" );
				((Mob)this.imp_in).Weaken( 7 );
			}
			GlobalFuncs.playsound( this.loc, "sound/items/timer.ogg", 30, 0 );
			Task13.Sleep( ((int)( this.delay / 4 )) );
			GlobalFuncs.playsound( this.loc, "sound/items/timer.ogg", 30, 0 );
			Task13.Sleep( ((int)( this.delay / 4 )) );
			GlobalFuncs.playsound( this.loc, "sound/items/timer.ogg", 30, 0 );
			Task13.Sleep( ((int)( this.delay / 4 )) );
			GlobalFuncs.explosion( this, this.heavy, this.medium, this.weak, this.weak, null, null, this.weak );

			if ( Lang13.Bool( this.imp_in ) ) {
				((Mob)this.imp_in).gib();
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: implant_explosive.dm
		public override int implant( dynamic source = null, dynamic user = null ) {
			dynamic imp_e = null;

			imp_e = Lang13.FindIn( this.type, source );

			if ( Lang13.Bool( imp_e ) && imp_e != this ) {
				imp_e.heavy += this.heavy;
				imp_e.medium += this.medium;
				imp_e.weak += this.weak;
				imp_e.delay += this.delay;
				GlobalFuncs.qdel( this );
				return 1;
			}
			return base.implant( (object)(source), (object)(user) );
		}

		// Function from file: implant_explosive.dm
		public override bool activate( dynamic cause = null ) {
			
			if ( !Lang13.Bool( cause ) || !Lang13.Bool( this.imp_in ) ) {
				return false;
			}

			if ( cause == "action_button" && Interface13.Alert( this.imp_in, "Are you sure you want to activate your microbomb implant? This will cause you to explode!", "Microbomb Implant Confirmation", "Yes", "No" ) != "Yes" ) {
				return false;
			}
			this.heavy = Num13.Floor( this.heavy );
			this.medium = Num13.Floor( this.medium );
			this.weak = Num13.Floor( this.weak );
			this.imp_in.WriteMsg( "<span class='notice'>You activate your microbomb implant.</span>" );

			if ( this.delay <= 7 ) {
				GlobalFuncs.explosion( this, this.heavy, this.medium, this.weak, this.weak, null, null, this.weak );

				if ( Lang13.Bool( this.imp_in ) ) {
					((Mob)this.imp_in).gib();
				}
				GlobalFuncs.qdel( this );
				return false;
			}
			this.timed_explosion();
			return false;
		}

		// Function from file: implant_explosive.dm
		public override void trigger( string emote = null, Mob_Living_Carbon_Human source = null ) {
			
			if ( emote == "deathgasp" ) {
				this.activate( "death" );
			}
			return;
		}

		// Function from file: implant_explosive.dm
		public override string get_data(  ) {
			string dat = null;

			dat = @"<b>Implant Specifications:</b><BR>
				<b>Name:</b> Robust Corp RX-78 Employee Management Implant<BR>
				<b>Life:</b> Activates upon death.<BR>
				<b>Important Notes:</b> Explodes<BR>
				<HR>
				<b>Implant Details:</b><BR>
				<b>Function:</b> Contains a compact, electrically detonated explosive that detonates upon receiving a specially encoded signal or upon host death.<BR>
				<b>Special Features:</b> Explodes<BR>
				";
			return dat;
		}

	}

}