// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Glowshroom : Obj_Effect {

		public double endurance = 30;
		public int potency = 30;
		public int delay = 1200;
		public bool floor = false;
		public int? yield = 3;
		public int spreadChance = 40;
		public int spreadIntoAdjacentChance = 60;
		public int evolveChance = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/lighting.dmi";
			this.icon_state = "glowshroomf";
			this.layer = 2.1;
		}

		// Function from file: glowshroom.dm
		public Obj_Effect_Glowshroom ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.dir = Convert.ToInt32( this.CalcDir() );

			if ( !this.floor ) {
				
				switch ((int)( this.dir )) {
					case 1:
						this.pixel_y = 32;
						break;
					case 2:
						this.pixel_y = -32;
						break;
					case 4:
						this.pixel_x = 32;
						break;
					case 8:
						this.pixel_x = -32;
						break;
				}
				this.icon_state = "glowshroom" + Rand13.Int( 1, 3 );
			} else {
				this.icon_state = "glowshroomf";
			}
			Task13.Schedule( this.delay, (Task13.Closure)(() => {
				this.set_light( Num13.Floor( this.potency / 10 ) );
				return;
			}));
			return;
		}

		// Function from file: glowshroom.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			
			if ( ( exposed_temperature ??0) > 300 ) {
				this.endurance -= 5;
				this.CheckEndurance();
			}
			return false;
		}

		// Function from file: glowshroom.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((int?)( severity )) {
				case 1:
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 5 ) ) {
						GlobalFuncs.qdel( this );
						return false;
					}
					break;
			}
			return false;
		}

		// Function from file: glowshroom.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			base.attackby( (object)(a), (object)(b), (object)(c) );
			this.endurance -= Convert.ToDouble( a.force );
			this.CheckEndurance();
			return null;
		}

		// Function from file: glowshroom.dm
		public void CheckEndurance(  ) {
			
			if ( this.endurance <= 0 ) {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: glowshroom.dm
		public dynamic CalcDir( Ent_Static location = null ) {
			location = location ?? this.loc;

			int direction = 0;
			dynamic wallDir = null;
			Tile newTurf = null;
			Obj_Effect_Glowshroom shroom = null;
			ByTable dirList = null;
			int? i = null;
			dynamic newDir = null;

			direction = 16;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.cardinal )) {
				wallDir = _a;
				
				newTurf = Map13.GetStep( location, Convert.ToInt32( wallDir ) );

				if ( newTurf.density ) {
					direction |= Convert.ToInt32( wallDir );
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( location, typeof(Obj_Effect_Glowshroom) )) {
				shroom = _b;
				

				if ( shroom == this ) {
					continue;
				}

				if ( shroom.floor ) {
					direction &= 65519;
				} else {
					direction &= ~shroom.dir;
				}
			}
			dirList = new ByTable();
			i = null;
			i = 1;

			while (( i ??0) <= 16) {
				
				if ( ( direction & ( i ??0) ) != 0 ) {
					dirList.Add( i );
				}
				i <<= 1;
			}

			if ( dirList.len != 0 ) {
				newDir = Rand13.PickFromTable( dirList );

				if ( newDir == 16 ) {
					this.floor = true;
					newDir = 1;
				}
				return newDir;
			}
			this.floor = true;
			return 1;
		}

		// Function from file: glowshroom.dm
		public void Spread(  ) {
			int spreaded = 0;
			int? i = null;
			ByTable possibleLocs = null;
			bool spreadsIntoAdjacent = false;
			Tile_Unsimulated_Floor_Asteroid earth = null;
			dynamic newLoc = null;
			int shroomCount = 0;
			int placeCount = 0;
			Obj_Effect_Glowshroom shroom = null;
			dynamic wallDir = null;
			Tile isWall = null;
			Obj_Effect_Glowshroom child = null;

			spreaded = 1;

			while (spreaded != 0) {
				spreaded = 0;
				i = null;
				i = 1;

				while (( i ??0) <= ( this.yield ??0)) {
					
					if ( Rand13.PercentChance( this.spreadChance ) ) {
						possibleLocs = new ByTable();
						spreadsIntoAdjacent = false;

						if ( Rand13.PercentChance( this.spreadIntoAdjacentChance ) ) {
							spreadsIntoAdjacent = true;
						}

						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 3 ), typeof(Tile_Unsimulated_Floor_Asteroid) )) {
							earth = _a;
							

							if ( spreadsIntoAdjacent || !Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Glowshroom), Map13.FetchInView( earth, 1 ) ) ) ) {
								possibleLocs.Add( earth );
							}
						}

						if ( !( possibleLocs.len != 0 ) ) {
							break;
						}
						newLoc = Rand13.PickFromTable( possibleLocs );
						shroomCount = 0;
						placeCount = 1;

						foreach (dynamic _b in Lang13.Enumerate( newLoc, typeof(Obj_Effect_Glowshroom) )) {
							shroom = _b;
							
							shroomCount++;
						}

						foreach (dynamic _c in Lang13.Enumerate( GlobalVars.cardinal )) {
							wallDir = _c;
							
							isWall = Map13.GetStep( newLoc, Convert.ToInt32( wallDir ) );

							if ( isWall.density ) {
								placeCount++;
							}
						}

						if ( shroomCount >= placeCount ) {
							
						} else {
							child = new Obj_Effect_Glowshroom( newLoc );
							child.potency = this.potency;
							child.yield = this.yield;
							child.delay = this.delay;
							child.endurance = this.endurance;
							spreaded++;
						}
					}
					i++;
				}

				if ( Rand13.PercentChance( this.evolveChance ) ) {
					this.potency += Rand13.Int( 4, 6 );
				}
				Task13.Sleep( this.delay );
			}
			return;
		}

	}

}