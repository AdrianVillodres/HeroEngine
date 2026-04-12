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
| 6            | -          | Abalon | 3     | 150   | 137           | -      | -          | Output: "Abalon receives 13 | HP: 137/150" |

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
| 4            | -          | Abalon | 1     | 50    | 30            | 0      | 0          | -                  |
| 5            | -          | Abalon | 1     | 50    | 30            | -      | -          | Output: "Abalon receives 0 | HP: 50/50" |

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
