// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Hallucination_Simple : Obj_Effect_Hallucination {

		public dynamic image_icon = "icons/mob/alien.dmi";
		public dynamic image_state = "alienh_pounce";
		public int? px = 0;
		public int? py = 0;
		public dynamic col_mod = null;
		public Image current_image = null;
		public int image_layer = 4;
		public bool active = true;

		// Function from file: Hallucination.dm
		public Obj_Effect_Hallucination_Simple ( dynamic loc = null, Ent_Static T = null ) : base( (object)(loc) ) {
			this.target = T;
			this.current_image = this.GetImage();

			if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
				((dynamic)this.target).client.images.Or( this.current_image );
			}
			return;
		}

		// Function from file: Hallucination.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
				((dynamic)this.target).client.images.Remove( this.current_image );
			}
			this.active = false;
			return base.Destroy();
		}

		// Function from file: Hallucination.dm
		public override bool Moved( Ent_Static OldLoc = null, int? Dir = null ) {
			this.Show();
			return false;
		}

		// Function from file: Hallucination.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			new_px = new_px ?? 0;
			new_py = new_py ?? 0;

			this.image_state = new_state;

			if ( Lang13.Bool( new_icon ) ) {
				this.image_icon = new_icon;
			} else {
				this.image_icon = Lang13.Initial( this, "image_icon" );
			}
			this.px = new_px;
			this.py = new_py;
			this.Show();
			return false;
		}

		// Function from file: Hallucination.dm
		public void Show( bool? update = null ) {
			update = update ?? true;

			
			if ( this.active ) {
				
				if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
					((dynamic)this.target).client.images.Remove( this.current_image );
				}

				if ( update == true ) {
					this.current_image = this.GetImage();
				}

				if ( Lang13.Bool( ((dynamic)this.target).client ) ) {
					((dynamic)this.target).client.images.Or( this.current_image );
				}
			}
			return;
		}

		// Function from file: Hallucination.dm
		public Image GetImage(  ) {
			Image I = null;

			I = new Image( this.image_icon, this.loc, this.image_state, this.image_layer, this.dir );
			I.pixel_x = this.px ??0;
			I.pixel_y = this.py ??0;

			if ( Lang13.Bool( this.col_mod ) ) {
				I.color = this.col_mod;
			}
			return I;
		}

	}

}