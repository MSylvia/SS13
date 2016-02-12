// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_Terminal : Obj_Machinery_Power {

		public Ent_Static master = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.level = 1;
			this.icon_state = "term";
			this.layer = 2.6;
		}

		// Function from file: terminal.dm
		public Obj_Machinery_Power_Terminal ( dynamic loc = null ) : base( (object)(loc) ) {
			Ent_Static T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			T = this.loc;

			if ( this.level == 1 ) {
				this.hide( Lang13.BoolNullable( ((dynamic)T).intact ) );
			}
			return;
		}

		// Function from file: terminal.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Obj_Item_Weapon_Wirecutters && !( this.master != null ) ) {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), GlobalFuncs.get_turf( this ), 10 );
				GlobalFuncs.qdel( this );
				return null;
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: terminal.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.master != null ) {
				((dynamic)this.master).terminal = null;
				this.master = null;
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: terminal.dm
		public override void hide( bool? h = null ) {
			
			if ( h == true ) {
				this.invisibility = 101;
				this.icon_state = "term-f";
			} else {
				this.invisibility = 0;
				this.icon_state = "term";
			}
			return;
		}

	}

}