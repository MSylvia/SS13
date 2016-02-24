// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_XenoAttack : Obj_Effect_Hallucination {

		public Obj_Machinery_Atmospherics_Components_Unary_VentPump pump = null;
		public Obj_Effect_Hallucination_Simple_Xeno xeno = null;

		// Function from file: Hallucination.dm
		public Obj_Effect_Hallucination_XenoAttack ( dynamic loc = null, Mob_Living_Carbon T = null ) : base( (object)(loc) ) {
			Obj_Machinery_Atmospherics_Components_Unary_VentPump U = null;
			string xeno_name = null;

			this.target = T;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this.target, 7 ), typeof(Obj_Machinery_Atmospherics_Components_Unary_VentPump) )) {
				U = _a;
				

				if ( !( U.welded == true ) ) {
					this.pump = U;
					break;
				}
			}

			if ( this.pump != null ) {
				this.xeno = new Obj_Effect_Hallucination_Simple_Xeno( this.pump.loc, this.target );
				Task13.Sleep( 10 );
				this.xeno.update_icon( "alienh_leap", "icons/mob/alienleap.dmi", -32, -32 );
				this.xeno.throw_at( this.target, 7, 1, null, false, true );
				Task13.Sleep( 10 );
				this.xeno.update_icon( "alienh_leap", "icons/mob/alienleap.dmi", -32, -32 );
				this.xeno.throw_at( this.pump, 7, 1, null, false, true );
				Task13.Sleep( 10 );
				xeno_name = this.xeno.name;
				((dynamic)this.target).WriteMsg( "<span class='notice'>" + xeno_name + " begins climbing into the ventilation system...</span>" );
				Task13.Sleep( 10 );
				GlobalFuncs.qdel( this.xeno );
				((dynamic)this.target).WriteMsg( "<span class='notice'>" + xeno_name + " scrambles into the ventilation ducts!</span>" );
			}
			GlobalFuncs.qdel( this );
			return;
		}

	}

}