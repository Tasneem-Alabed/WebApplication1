# Async-Inn

## Tasneem Alabed

Sunday, July 16, 2023

![imgErd](img1.png)

## Exeplanation :
### The Hotel Table =>
+ It includes the Hotel_ID which is the **Primary Key** that means it's unique for each Hotel . It also has the city , phone number, Address , Name , Number of rooms and the state attributes, each one of them represent specific attribute for the Hotel and The Hotel entity has a **One to many** relation with the Room and the Price which means each Hotel can have multiple rooms with different prices.

### The Room Table => 
+ It includes the Room_ID as a primary key and it has **one to one** relation with the Price since each room has specific price depends on it's location, features (Aminities) and it's layout. it also has another **Many to Many** relationship with the aminities since the room can has more than one aminity and each aminity can be in several rooms , It has **Many to one** relationship with the type and the Layout enum , and finally it has one to one with the price .

### The Price Table => 
+ It has Hotel_ID and Room_ID both as foriegn key with 2 relations one with the Hotel and the other with the Room

### The aminities Table => 
+ It specify the features each room has like air conditioning, cofee maker , ocean view and others . It has ID and name and it connect with **Many to Many** relationship with the Room table.

### The Room_Type Table => 
+ It specify the room type , with one or 2 bedrooms or studio . It contains the nickname that depends on the type .

### The Layout Enum => 
+ It has the nickname of the room that depends on it . It contains several layouts of the rooms.

## Hotel System 
this app present the data of hotels that stor in database 
we have 5 tabels eachone has Id  and there are a relation between table that was
explain in the explanation part 

## to use this app

1- you should install packeges 

- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.VisualStudio.Web.CodeGeneration
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
 then when the app run it will open in the browser so 
after the link add /api/{table name}

## Repository Pattern:
In this part of code I put three interface(IRoom , IHoel,IAmenities) and add
three services (HotelServices , RoomServicse , AmenitiesServicse)
It acts as a repository for related data operations (hotel/room/amenities)
The IHotel IRoom IAmenity interfaces serves as a contract that any class representing a (hotel/room/amenity) repository .

 do
### add new routing 

create relation between table 


## Routes

<br></br>
1-  /api/Hotels/{hotelId}/Rooms this route to get all rooms for hotel

2-  /api/Hotels/{hotelId}/Rooms this rout to add rome to the hotel

3-  /api/Hotels/{hotelId}/Rooms/{roomNumber} this route to get all room information for a room

4-  /api/Hotels/{hotelId}/Rooms/{roomNumber}  this route to update the information for rooms

5-  /api/Hotels/{hotelId}/Rooms/{roomNumber} this route to delete room from hotel    

