// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Canvas : Obj_Item_Weapon {

		public int whichGlobalBackup = 1;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.burn_state = 0;
			this.icon = "icons/obj/artstuff.dmi";
			this.icon_state = "11x11";
		}

		public Obj_Item_Weapon_Canvas ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: artstuff.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Icon blank = null;

			
			if ( !Lang13.Bool( user ) ) {
				return null;
			}
			blank = this.getGlobalBackup();

			if ( blank != null ) {
				this.icon = blank;
				((Ent_Static)user).visible_message( "<span class='notice'>" + user + " cleans the canvas.</span>", "<span class='notice'>You clean the canvas.</span>" );
			}
			return null;
		}

		// Function from file: artstuff.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			ByTable click_params = null;
			double? pixX = null;
			double? pixY = null;
			Icon masterpiece = null;
			string thePix = null;
			Icon Ico = null;
			string theOriginalPix = null;
			dynamic C = null;

			click_params = String13.ParseUrlParams( _params );
			pixX = String13.ParseNumber( click_params["icon-x"] );
			pixY = String13.ParseNumber( click_params["icon-y"] );

			if ( !( click_params != null ) || !Lang13.Bool( click_params["icon-x"] ) || !Lang13.Bool( click_params["icon-y"] ) ) {
				return null;
			}

			if ( A is Obj_Item_Weapon_Soap || A is Obj_Item_Weapon_ReagentContainers_Glass_Rag ) {
				masterpiece = new Icon( this.icon, this.icon_state );
				thePix = masterpiece.GetPixel( pixX, pixY );
				Ico = this.getGlobalBackup();

				if ( !( Ico != null ) ) {
					GlobalFuncs.qdel( masterpiece );
					return null;
				}
				theOriginalPix = Ico.GetPixel( pixX, pixY );

				if ( thePix != theOriginalPix ) {
					this.DrawPixelOn( theOriginalPix, pixX, pixY );
				}
				GlobalFuncs.qdel( masterpiece );
				return null;
			}

			if ( A is Obj_Item_Toy_Crayon ) {
				C = A;
				this.DrawPixelOn( C.paint_color, pixX, pixY );
				return null;
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: artstuff.dm
		public Icon getGlobalBackup(  ) {
			Icon _default = null;

			Icon I = null;

			_default = null;

			if ( Lang13.Bool( GlobalVars.globalBlankCanvases[this.whichGlobalBackup] ) ) {
				_default = GlobalVars.globalBlankCanvases[this.whichGlobalBackup];
			} else {
				I = new Icon( Lang13.Initial( this, "icon" ), Lang13.Initial( this, "icon_state" ) );
				GlobalVars.globalBlankCanvases[this.whichGlobalBackup] = I;
				_default = I;
			}
			return _default;
		}

	}

}