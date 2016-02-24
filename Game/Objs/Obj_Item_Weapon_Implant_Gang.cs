// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Implant_Gang : Obj_Item_Weapon_Implant {

		public dynamic gang = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.activated = false;
			this.origin_tech = "materials=2;biotech=4;programming=4;syndicate=4";
		}

		// Function from file: gang_pen.dm
		public Obj_Item_Weapon_Implant_Gang ( dynamic loc = null, dynamic setgang = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.gang = setgang;
			return;
		}

		// Function from file: gang_pen.dm
		public override int implant( dynamic source = null, dynamic user = null ) {
			Obj_Item_Weapon_Implant I = null;
			bool? success = null;

			
			if ( base.implant( (object)(source), (object)(user) ) != 0 ) {
				
				foreach (dynamic _a in Lang13.Enumerate( source, typeof(Obj_Item_Weapon_Implant) )) {
					I = _a;
					

					if ( I != this ) {
						GlobalFuncs.qdel( I );
					}
				}

				if ( !Lang13.Bool( source.mind ) || Convert.ToInt32( source.stat ) == 2 ) {
					return 0;
				}
				success = null;

				if ( ((GameMode)GlobalVars.ticker.mode).get_gangsters().Contains( source.mind ) ) {
					
					if ( ((GameMode)GlobalVars.ticker.mode).remove_gangster( source.mind, false, 1 ) ) {
						success = true;
					}
				} else {
					success = true;
				}

				if ( source is Mob_Living_Carbon_Human ) {
					
					if ( !( success == true ) ) {
						((Ent_Static)source).visible_message( "<span class='warning'>" + source + " seems to resist the implant!</span>", "<span class='warning'>You feel the influence of your enemies try to invade your mind!</span>" );
					}
				}
				GlobalFuncs.qdel( this );
				return -1;
			}
			return 0;
		}

		// Function from file: gang_pen.dm
		public override string get_data(  ) {
			string dat = null;

			dat = @"<b>Implant Specifications:</b><BR>
				<b>Name:</b> Criminal Loyalty Implant<BR>
				<b>Life:</b> A few seconds after injection.<BR>
				<b>Important Notes:</b> Illegal<BR>
				<HR>
				<b>Implant Details:</b><BR>
				<b>Function:</b> Contains a small pod of nanobots that change the host's brain to be loyal to a certain organization.<BR>
				<b>Special Features:</b> This device will also emit a small EMP pulse, destroying any other implants within the host's brain.<BR>
				<b>Integrity:</b> Implant's EMP function will destroy itself in the process.";
			return dat;
		}

	}

}