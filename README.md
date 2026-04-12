## Chapter 1

### Test case 1

**Character1:** Dalia (Level 3, MaxHP 150, CurrentHealth 150)  
**Character2:** Abalon (Level 3, MaxHP 150, CurrentHealth 150)  
**Damage:** 13  

| #Instruction | #Iteration | Name   | Level | MaxHP | CurrentHealth | Damage | RealDamage | Condition / Output |
|--------------|------------|--------|-------|-------|---------------|--------|------------|--------------------|
| 1            | -          | Abalon | 3     | 150   | 150           | -      | -          | -                  |
| 2            | -          | Dalia  | 3     | 150   | 150           | -      | -          | -                  |
| 3            | -          | Dalia  | 3     | 150   | 150           | 13     | 13         | -                  |
| 4            | -          | Dalia  | 3     | 150   | 150           | 13     | 13         | -                  |
| 5            | -          | Abalon | 3     | 150   | 137           | 13     | 13         | -                  |
| 6            | -          | Abalon | 3     | 150   | 137           | -      | -          | Output: "Abalon receives 13 HP: 137/150" |

---

### Test case 2

**Character1:** Dalia (Level 1, MaxHP 50, CurrentHealth 50)  
**Character2:** Abalon (Level 1, MaxHP 50, CurrentHealth 50)  
**Damage:** 0  

| #Instruction | #Iteration | Name   | Level | MaxHP | CurrentHealth | Damage | RealDamage | Condition / Output |
|--------------|------------|--------|-------|-------|---------------|--------|------------|--------------------|
| 1            | -          | Dalia  | 1     | 50    | 50            | -      | -          | -                  |
| 2            | -          | Dalia  | 1     | 50    | 50            | 0      | 0          | -                  |
| 3            | -          | Dalia  | 1     | 50    | 50            | -      | 20         | -                  |
| 4            | -          | Abalon | 1     | 50    | 50            | 0      | 0          | -                  |
| 5            | -          | Abalon | 1     | 50    | 50            | -      | -          | Output: "Abalon receives 0 HP: 50/50" |

---

### Test case 3

**Character1:** Dalia (Level 3, MaxHP 150, CurrentHealth 150)  
**Character2:** Abalon (Level 3, MaxHP 150, CurrentHealth 150)  
**Damage:** 13  

| #Instruction | #Iteration | Name   | Level | MaxHP | DefenseBuffCount | Damage | RealDamage | Condition        |
|--------------|------------|--------|-------|-------|------------------|--------|------------|------------------|
| 1            | -          | Dalia  | 3     | 150   | 0                | -      | -          | -                |
| 2            | -          | Dalia  | 3     | 150   | 0                | 13     | 0          | -                |
| 3            | -          | Dalia  | 3     | 150   | 0                | -      | 0          | -                |
| 4            | -          | Abalon | 3     | 150   | 150              | 0      | 0          | No damage applied |

---
## Chapter 2

## Test case 1: name = Swartz of the Ice Queen, rarity = Legendary, Type = Attack

| #Instruction | #Iteration | Name                    | Rarity     | Type   | Cost           | Power          | Condition |
|--------------|------------|-------------------------|------------|--------|----------------|----------------|-----------|
| -            |            |                         |            |        |                |                |           |
|              |            | Name                    | Rarity     | Type   | Cost           | Power          | Condition |
| 1            | -          | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    |           |
| 2            | -          | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    | dalia.Add(swartz) |
| 3            | -          | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    | dalia.listAllAbilities() |
| 4           |            | Swartz of the Ice Queen | Legendary  | Attack | (int)Rarity    | (int)Rarity    | Output: [Legendary]   Swartz of the Ice Queen     Type: Attack       Cost: 40 mana |

---

## Test case 2: name = Rock throw, rarity = Common, Type = Attack

| #Instruction | #Iteration | Name       | Rarity | Type   | Cost        | Power       | Condition |
|--------------|------------|------------|--------|--------|-------------|-------------|-----------|
| -            |            |            |        |        |             |             |           |
|              |            | Name       | Rarity | Type   | Cost        | Power       | Condition |
| 1            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity |           |
| 2            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | dalia.Add(throw) |
| 3            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | dalia.listAllAbilities() |
| 4            |            | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | Output: [Common]   Rock throw    Type: Attack       Cost: 5 mana |

---

## Test case 3: name = Rock throw, rarity = Common, Type = Attack (We are assuming that we already have this ability in the list)

| #Instruction | #Iteration | Name       | Rarity | Type   | Cost        | Power       | Condition |
|--------------|------------|------------|--------|--------|-------------|-------------|-----------|
| -            |            |            |        |        |             |             |           |
|              |            | Name       | Rarity | Type   | Cost        | Power       | Condition |
| 1            | -          | Rock throw | Common | -      | -           | -           |           |
| 2            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | dalia.Add(throw) |
| 3            | -          | Rock throw | Common | Attack | (int)Rarity | (int)Rarity | Output = “This hero already has the ability” |
