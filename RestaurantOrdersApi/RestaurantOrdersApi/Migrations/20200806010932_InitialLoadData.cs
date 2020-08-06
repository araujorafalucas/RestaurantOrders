using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantOrdersApi.Migrations
{
    public partial class InitialLoadData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO DishTypes
(Description, Sequence, IsEnable)
VALUES
 ('entrée',1,1)
,('side',2,1)
,('drink',3,1)
,('dessert',4,1)

----------------------------------------

INSERT INTO Dishes
(Description, IsEnable, DishTypeId)
VALUES
 ('eggs',1,1)
,('steak',1,1)
,('Toast',1,2)
,('potato',1,2)
,('coffee',1,3)
,('wine',1,3)
,('cake',1,4)

-----------------------------------------------------

INSERT INTO MealTimes
(Description, IsEnable)
VALUES
('morning',1)
,('night',1)

-----------------------------------------------------

INSERT INTO DishesMealTimes
(DishId, MealTimeId, MaxAllowed)
VALUES
(1,1,1)	
,(3,1,1)
,(5,1,-1)
,(2,2,1)
,(4,2,-1)
,(6,2,1)
,(7,2,1)



");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
