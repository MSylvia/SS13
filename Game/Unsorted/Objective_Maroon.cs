// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Objective_Maroon : Objective {

		public bool? target_role_type = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dangerrating = 5;
			this.martyr_compatible = true;
		}

		public Objective_Maroon ( string text = null ) : base( text ) {
			
		}

		// Function from file: objective.dm
		public override void update_explanation_text(  ) {
			
			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) ) {
				this.explanation_text = "Prevent " + this.target.name + ", the " + ( !( this.target_role_type == true ) ? this.target.assigned_role : ((dynamic)( this.target.special_role )) ) + ", from escaping alive.";
			} else {
				this.explanation_text = "Free Objective";
			}
			return;
		}

		// Function from file: objective.dm
		public override int check_completion(  ) {
			
			if ( Lang13.Bool( this.target ) && Lang13.Bool( this.target.current ) ) {
				
				if ( Convert.ToInt32( this.target.current.stat ) == 2 || this.target.current is Mob_Living_Silicon || this.target.current is Mob_Living_Carbon_Brain || Convert.ToDouble( this.target.current.z ) > 6 || !Lang13.Bool( this.target.current.ckey ) ) {
					return 1;
				}

				if ( ((Ent_Static)this.target.current).onCentcom() || ((Ent_Static)this.target.current).onSyndieBase() ) {
					return 0;
				}
			}
			return 1;
		}

		// Function from file: objective.dm
		public override dynamic find_target_by_role( string role = null, bool? role_type = null, bool? invert = null ) {
			role_type = role_type ?? false;
			invert = invert ?? false;

			
			if ( !( invert == true ) ) {
				this.target_role_type = role_type;
			}
			base.find_target_by_role( role, role_type, invert );
			return this.target;
		}

	}

}