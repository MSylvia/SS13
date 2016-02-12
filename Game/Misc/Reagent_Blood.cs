// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Blood : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blood";
			this.id = "blood";
			this.reagent_state = 2;
			this.color = "#a00000";
			this.data = new ByTable()
				.Set("donor", null)
				.Set("viruses", null)
				.Set("blood_DNA", null)
				.Set("blood_type", null)
				.Set("blood_colour", "#A10808")
				.Set("resistances", null)
				.Set("trace_chem", null)
				.Set("antibodies", null);
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_removal( dynamic data = null ) {
			dynamic H = null;

			
			if ( this.holder != null && Lang13.Bool( ((dynamic)this.holder).my_atom ) ) {
				H = ((dynamic)this.holder).my_atom;

				if ( H is Mob_Living_Carbon_Human ) {
					
					if ( Lang13.Bool( H.species ) && Lang13.Bool( H.species.flags & 1 ) ) {
						return false;
					}
				}
			}
			return true;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_turf( dynamic T = null, double volume = 0 ) {
			Reagent_Blood self = null;
			dynamic blood_prop = null;
			Disease D = null;
			dynamic newVirus = null;
			dynamic B = null;
			dynamic B2 = null;

			self = this;

			if ( base.reaction_turf( (object)(T), volume ) ) {
				return true;
			}

			if ( volume < 3 ) {
				return false;
			}

			if ( !Lang13.Bool( self.data["donor"] ) || self.data["donor"] is Mob_Living_Carbon_Human ) {
				blood_prop = Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_Blood), T );

				if ( !Lang13.Bool( blood_prop ) ) {
					blood_prop = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood), T );
					blood_prop.New( T );
					blood_prop.blood_DNA[self.data["blood_DNA"]] = self.data["blood_type"];
				}

				foreach (dynamic _a in Lang13.Enumerate( self.data["viruses"], typeof(Disease) )) {
					D = _a;
					
					newVirus = D.Copy( true );
					blood_prop.viruses += newVirus;
				}
			}

			if ( !Lang13.Bool( self.data["donor"] ) || self.data["donor"] is Mob_Living_Carbon_Human ) {
				GlobalFuncs.blood_splatter( T, self, true );
			} else if ( self.data["donor"] is Mob_Living_Carbon_Monkey ) {
				B = GlobalFuncs.blood_splatter( T, self, true );

				if ( Lang13.Bool( B ) ) {
					B.blood_DNA["Non-Human DNA"] = "A+";
				}
			} else if ( self.data["donor"] is Mob_Living_Carbon_Alien ) {
				B2 = GlobalFuncs.blood_splatter( T, self, true );

				if ( Lang13.Bool( B2 ) ) {
					B2.blood_DNA["UNKNOWN DNA STRUCTURE"] = "X*";
				}
			}

			if ( volume >= 5 && !( T.loc is Zone_Chapel ) ) {
				T.holy = false;
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override void on_update( dynamic A = null ) {
			
			if ( Lang13.Bool( this.data["blood_colour"] ) ) {
				this.color = this.data["blood_colour"];
			}
			base.on_update( (object)(A) ); return;
		}

		// Function from file: Chemistry-Reagents.dm
		public override void on_merge( dynamic data = null ) {
			
			if ( Lang13.Bool( data["blood_colour"] ) ) {
				this.color = data["blood_colour"];
			}
			base.on_merge( (object)(data) ); return;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			Reagent_Blood self = null;
			Disease D = null;
			dynamic C = null;
			dynamic H = null;
			dynamic B = null;

			self = this;

			if ( base.reaction_mob( (object)(M), method, volume ) ) {
				return true;
			}

			if ( Lang13.Bool( self.data ) && Lang13.Bool( self.data["viruses"] ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( self.data["viruses"], typeof(Disease) )) {
					D = _a;
					

					if ( D.spread_type == -1 || D.spread_type == 0 ) {
						continue;
					}

					if ( method == GlobalVars.TOUCH ) {
						((Mob)M).contract_disease( D );
					} else {
						((Mob)M).contract_disease( D, true, false );
					}
				}
			}

			if ( M is Mob_Living_Carbon ) {
				C = M;

				if ( Lang13.Bool( self.data ) && Lang13.Bool( self.data["virus2"] ) ) {
					
					if ( method == GlobalVars.TOUCH ) {
						GlobalFuncs.infect_virus2( C, self.data["virus2"], null, "(Contact with blood)" );
					} else {
						GlobalFuncs.infect_virus2( C, self.data["virus2"], true, "(INJECTED)" );
					}
				}

				if ( Lang13.Bool( self.data ) && Lang13.Bool( self.data["antibodies"] ) ) {
					C.antibodies = ((int)( C.antibodies )) | ( Convert.ToInt32( self.data["antibodies"] ) );
				}

				if ( C is Mob_Living_Carbon_Human && method == GlobalVars.TOUCH ) {
					H = C;
					((Mob_Living_Carbon_Human)H).bloody_body( self.data["donor"] );

					if ( Lang13.Bool( self.data["donor"] ) ) {
						((Mob_Living_Carbon_Human)H).f_bloody_hands( self.data["donor"] );
					}
					Task13.Schedule( 0, (Task13.Closure)(() => {
						B = Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_Blood), GlobalFuncs.get_turf( H ) );

						if ( Lang13.Bool( B ) ) {
							((Base_Dynamic)B).Crossed( H );
						}
						return;
					}));
					H.update_icons();
				}
			}
			return false;
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.adjust_nutrient( 0.5, 1 );
			T.adjust_water( 061 );
			return;
		}

	}

}