// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease : Game_Data {

		public int visibility_flags = 0;
		public int disease_flags = 7;
		public int spread_flags = 64;
		public string form = "Virus";
		public string name = "No disease";
		public string desc = "";
		public string agent = "some microbes";
		public string spread_text = "";
		public string cure_text = "";
		public int? stage = 1;
		public int max_stages = 0;
		public int stage_prob = 4;
		public int longevity = 150;
		public ByTable viable_mobtypes = new ByTable();
		public dynamic affected_mob = null;
		public dynamic holder = null;
		public ByTable cures = new ByTable();
		public int infectivity = 65;
		public int cure_chance = 8;
		public bool carrier = false;
		public double permeability_mod = 1;
		public string severity = "No threat";
		public ByTable required_organs = new ByTable();
		public bool needs_all_cures = true;
		public ByTable strain_data = new ByTable();

		// Function from file: _disease.dm
		public Disease (  ) {
			dynamic H = null;
			Obj_Item_Organ O = null;

			
			if ( this.required_organs != null && this.required_organs.len != 0 ) {
				
				if ( this.affected_mob is Mob_Living_Carbon_Human ) {
					H = this.affected_mob;

					foreach (dynamic _a in Lang13.Enumerate( this.required_organs, typeof(Obj_Item_Organ) )) {
						O = _a;
						

						if ( !Lang13.Bool( Lang13.FindIn( O, H.organs ) ) ) {
							
							if ( !Lang13.Bool( Lang13.FindIn( O, H.internal_organs ) ) ) {
								this.cure();
								return;
							}
						}
					}
				}
			}
			GlobalVars.SSdisease.processing.Add( this );
			return;
		}

		// Function from file: _disease.dm
		public override dynamic Destroy(  ) {
			GlobalVars.SSdisease.processing.Remove( this );
			return base.Destroy();
		}

		// Function from file: _disease.dm
		public override int? process( dynamic seconds = null ) {
			Disease D = null;

			
			if ( !Lang13.Bool( this.holder ) ) {
				GlobalVars.SSdisease.processing.Remove( this );
				return null;
			}

			if ( Rand13.PercentChance( this.infectivity ) ) {
				this.spread( this.holder );
			}

			if ( Lang13.Bool( this.affected_mob ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.affected_mob.viruses, typeof(Disease) )) {
					D = _a;
					

					if ( D != this ) {
						
						if ( this.IsSame( D ) ) {
							GlobalFuncs.qdel( D );
						}
					}
				}

				if ( this.holder == this.affected_mob ) {
					
					if ( Convert.ToInt32( this.affected_mob.stat ) != 2 ) {
						this.stage_act();
					}
				}
			}

			if ( !Lang13.Bool( this.affected_mob ) ) {
				
				if ( Rand13.PercentChance( 70 ) ) {
					
					if ( --this.longevity <= 0 ) {
						this.cure();
					}
				}
			}
			return null;
		}

		// Function from file: _disease.dm
		public void remove_virus(  ) {
			this.affected_mob.viruses -= this;
			((Mob_Living_Carbon)this.affected_mob).med_hud_set_status();
			return;
		}

		// Function from file: _disease.dm
		public bool IsSpreadByTouch(  ) {
			
			if ( ( this.spread_flags & 8 ) != 0 || ( this.spread_flags & 16 ) != 0 || ( this.spread_flags & 32 ) != 0 ) {
				return true;
			}
			return false;
		}

		// Function from file: _disease.dm
		public virtual dynamic GetDiseaseID(  ) {
			return this.type;
		}

		// Function from file: _disease.dm
		public virtual dynamic Copy( bool? process = null ) {
			dynamic D = null;

			D = Lang13.Call( this.type );
			D.strain_data = this.strain_data.Copy();
			return D;
		}

		// Function from file: _disease.dm
		public virtual bool IsSame( dynamic D = null ) {
			
			if ( Lang13.Bool( ((dynamic)D.type).IsInstanceOfType( this ) ) ) {
				return true;
			}
			return false;
		}

		// Function from file: _disease.dm
		public virtual void cure( dynamic resistance = null ) {
			
			if ( Lang13.Bool( this.affected_mob ) ) {
				
				if ( ( this.disease_flags & 4 ) != 0 ) {
					
					if ( !this.affected_mob.resistances.Contains( this.type ) ) {
						this.affected_mob.resistances.Add( this.type );
						this.remove_virus();
					}
				}
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: _disease.dm
		public void spread( dynamic source = null, int? force_spread = null ) {
			force_spread = force_spread ?? 0;

			int? spread_range = null;
			Mob_Living_Carbon C = null;

			
			if ( ( ( this.spread_flags & 1 ) != 0 || ( this.spread_flags & 2 ) != 0 || ( this.spread_flags & 4 ) != 0 ) && !Lang13.Bool( force_spread ) ) {
				return;
			}

			if ( Lang13.Bool( this.affected_mob ) ) {
				
				if ( Lang13.Bool( ((Reagents)this.affected_mob.reagents).has_reagent( "spaceacillin" ) ) || this.affected_mob.satiety > 0 && Rand13.PercentChance( ((int)( this.affected_mob.satiety / 10 )) ) ) {
					return;
				}
			}
			spread_range = 1;

			if ( Lang13.Bool( force_spread ) ) {
				spread_range = force_spread;
			}

			if ( ( this.spread_flags & 64 ) != 0 ) {
				spread_range++;
			}

			if ( !Lang13.Bool( source ) ) {
				
				if ( Lang13.Bool( this.affected_mob ) ) {
					source = this.affected_mob;
				} else {
					return;
				}
			}

			if ( source.loc is Tile ) {
				
				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( source, spread_range ), typeof(Mob_Living_Carbon) )) {
					C = _a;
					

					if ( C.loc is Tile ) {
						
						if ( Lang13.Bool( GlobalFuncs.AStar( source, C.loc, typeof(Tile).GetMethod( "Distance" ), spread_range, null, null, ( ( this.spread_flags & 64 ) != 0 ? typeof(Tile).GetMethod( "reachableAdjacentAtmosTurfs" ) : typeof(Tile).GetMethod( "reachableAdjacentTurfs" ) ) ) ) ) {
							C.ContractDisease( this );
						}
					}
				}
			}
			return;
		}

		// Function from file: _disease.dm
		public int has_cure(  ) {
			int _default = 0;

			dynamic C_id = null;

			
			if ( !( ( this.disease_flags & 1 ) != 0 ) ) {
				return 0;
			}
			_default = this.cures.len;

			foreach (dynamic _a in Lang13.Enumerate( this.cures )) {
				C_id = _a;
				

				if ( !Lang13.Bool( ((Reagents)this.affected_mob.reagents).has_reagent( C_id ) ) ) {
					_default--;
				}
			}

			if ( !( _default != 0 ) || this.needs_all_cures && _default < this.cures.len ) {
				return 0;
			}
			return _default;
		}

		// Function from file: _disease.dm
		public virtual void stage_act(  ) {
			int cure = 0;

			cure = this.has_cure();

			if ( this.carrier && !( cure != 0 ) ) {
				return;
			}
			this.stage = Num13.MinInt( this.stage ??0, this.max_stages );

			if ( !( cure != 0 ) ) {
				
				if ( Rand13.PercentChance( this.stage_prob ) ) {
					this.stage = Num13.MinInt( ( this.stage ??0) + 1, this.max_stages );
				}
			} else if ( Rand13.PercentChance( this.cure_chance ) ) {
				this.stage = Num13.MaxInt( ( this.stage ??0) - 1, 1 );
			}

			if ( ( this.disease_flags & 1 ) != 0 ) {
				
				if ( cure != 0 && Rand13.PercentChance( this.cure_chance ) ) {
					this.cure();
				}
			}
			return;
		}

	}

}