﻿

using System.Collections.Generic;
using System.Threading;
using System;
using Winform_Grab;
namespace Winform_Grab
{
    public class DistanceCalculator
    {
        private const double R = 6371; // Bán kính Trái Đất (km)

        public static double CalculateDistance(Location location1, Location location2)
        {
            double lat1 = DegreeToRadian(location1.Latitude);
            double lon1 = DegreeToRadian(location1.Longitude);
            double lat2 = DegreeToRadian(location2.Latitude);
            double lon2 = DegreeToRadian(location2.Longitude);

            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;

            double a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                       Math.Cos(lat1) * Math.Cos(lat2) *
                       Math.Pow(Math.Sin(deltaLon / 2), 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return R * c; // Khoảng cách theo km
        }

        private static double DegreeToRadian(double degree)
        {
            return (degree * Math.PI / 180.0);
        }
    }

    public class PriceCalculator
    {
        static int car = 10000;
        static int bike = 5000;
        public static double CalculatePrice(double distance, bool type)
        {
            if (type == false)
            {
                return distance * car;
            }
            else
            {
                return distance * bike;
            }
        }
    }

    public class LookForDriver
    {
        private static double k = 1; // km
        private const double MAX_K = 3; // km, giới hạn tối đa

        public static Driver FindDriver(Location location, bool carType, double k = 1)
        {
            List<Driver> drivers = DataManager.LoadDrivers();

            if (drivers.Count == 0)
            {
                return null;
            }

            foreach (Driver d in drivers)
            {
                if (d.VehicleType == carType && d.Availability)
                {
                    double distance = DistanceCalculator.CalculateDistance(location, d.Location);
                    Console.WriteLine($"Distance: {distance}");
                    if (distance < k)
                    {
                        return d;
                    }
                }
            }

            if (k + 1 <= MAX_K)
            {
                return FindDriver(location, carType, k + 1); // Truyền k vào thay vì dùng biến static
            }

            return null;
        }
    }

    public class TripHandler
    {
        public static Trip CreateTrip(Customer CurrentCustomer, Location startLocation, Location EndLocation, Driver driver, double distance, double price)
        {
            string ID = TripHandler.GenerateID();
            IPayment payment = PaymentGenerator.GenerateRandomPayment();
            List<string> paymentMethod = new List<string>();
            paymentMethod = payment.Pay();
            Trip trip = new Trip(ID, startLocation, EndLocation, driver.Id, CurrentCustomer.Id, distance, price);
            trip.PaymentMethod = paymentMethod;
            DataManager.AddTrip(trip);
            return trip;
        }

        public static string GenerateID()
        {
            string timestamp = DateTime.UtcNow.Ticks.ToString();
            string random = new Random().Next(1000, 9999).ToString();
            return random;
        }
    }

    public class TripHistory
    {
        private Customer customer;
        private List<Trip> trips;

        public TripHistory(Customer customer)
        {
            this.customer = customer;
            trips = new List<Trip>();
            LoadTripsForCustomer();
        }

        // Tải danh sách chuyến đi của khách hàng từ DataManager
        private void LoadTripsForCustomer()
        {
            List<Trip> allTrips = DataManager.LoadTrips();
            for (int i = 0; i < allTrips.Count; i++)
            {
                if (allTrips[i].CustomerId == customer.Id)
                {
                    trips.Add(allTrips[i]);
                }
            }
        }

        // In thông tin lịch sử chuyến đi
        public void PrintTripHistory()
        {
            if (trips.Count == 0)
            {
                Console.WriteLine("Khách hàng " + customer.Name + " chưa có chuyến đi nào.");
                return;
            }

            // In thông tin khách hàng một lần
            Console.WriteLine("Lịch sử chuyến đi của khách hàng:");
            Console.WriteLine($"ID: {customer.Id}, Tên: {customer.Name}, SĐT: {customer.PhoneNumber}");

            // In danh sách chuyến đi
            Console.WriteLine("Danh sách chuyến đi:");
            for (int i = 0; i < trips.Count; i++)
            {
                Trip trip = trips[i];
                string paymentMethods = trip.PaymentMethod.Count > 0 ? string.Join(", ", trip.PaymentMethod) : "Chưa xác định";
                Console.WriteLine($" - Chuyến {trip.Id}: Khoảng cách: {trip.Distance}km, Giá: {trip.Price}, Phương thức thanh toán: {paymentMethods}");
            }

            // Tính và in tổng tiền
            double totalPrice = CalculateTotalPrice();
            Console.WriteLine($"Tổng tiền đã trả: {totalPrice}");
        }

        // Tính tổng tiền bằng toán tử +
        private double CalculateTotalPrice()
        {
            if (trips.Count == 0)
            {
                return 0;
            }

            Trip totalTrip = trips[0];
            for (int i = 1; i < trips.Count; i++)
            {
                totalTrip = totalTrip + trips[i];
            }
            return totalTrip.Price;
        }

        public static void ViewTripHistory(Customer currentCustomer)
        {
            Console.WriteLine("\nLịch sử chuyến đi:");
            TripHistory history = new TripHistory(currentCustomer);
            history.PrintTripHistory();
        }
    }

    public class Login
    {
        public static Customer CusLogin()
        {
            bool check = false;
            Customer currentCustomer = null;
            while (!check)
            {
                Console.WriteLine("Đăng nhập");
                Console.Write("Nhập số điện thoại: ");
                string phoneNumber;
                int number;
                while (!int.TryParse(phoneNumber = Console.ReadLine(), out number))

                    Console.Write("Nhập mật khẩu: ");
                string password = Console.ReadLine();
                //while (!int.TryParse(Console.ReadLine(), out password))
                //{
                //    Console.Write("Mật khẩu không hợp lệ. Nhập lại: ");
                //}

                check = DataManager.VerifyUserCredentials(phoneNumber, password);
                if (check)
                {
                    Console.WriteLine("Đăng nhập thành công");
                    currentCustomer = DataManager.GetCustomerByPhoneNumber(phoneNumber);
                    if (currentCustomer != null)
                    {
                        Console.WriteLine($"Xin chào {currentCustomer.Name}");
                        return currentCustomer;
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy thông tin khách hàng.");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Sai số điện thoại hoặc mật khẩu. Vui lòng thử lại.");
                }
            }
            return null;
        }
    }

    public class Book
    {
        public static void BookTrip(Customer currentCustomer)
        {
            Console.WriteLine("\nNhập thông tin chuyến đi:");
            Console.WriteLine("Nhập tọa độ nơi bắt đầu:");
            Console.Write("Nhập kinh độ (longitude): ");
            double sLongitude = Check.GetValidDoubleInput();
            Console.Write("Nhập vĩ độ (latitude): ");
            double sLatitude = Check.GetValidDoubleInput();
            Location startLocation = new Location(sLatitude, sLongitude);

            Console.WriteLine("Nhập tọa độ nơi cần đến:");
            Console.Write("Nhập kinh độ (longitude): ");
            double eLongitude = Check.GetValidDoubleInput();
            Console.Write("Nhập vĩ độ (latitude): ");
            double eLatitude = Check.GetValidDoubleInput();
            Location endLocation = new Location(eLatitude, eLongitude);

            Console.WriteLine("Nhập loại xe (car/bike): ");
            string vehicleInput = Console.ReadLine().ToLower();
            bool carType = vehicleInput == "car" ? false : true;

            // Tìm tài xế trước
            Driver driver = LookForDriver.FindDriver(startLocation, carType);
            if (driver == null)
            {
                Console.WriteLine("Không tìm thấy tài xế phù hợp. Vui lòng thử lại sau.");
                return;
            }
            Console.WriteLine($"Đã tìm thấy tài xế: {driver.Name} ({(carType ? "Bike" : "Car")})");

            // Tính khoảng cách và giá tiền sau khi tìm thấy tài xế
            double distance = DistanceCalculator.CalculateDistance(startLocation, endLocation);
            double price = PriceCalculator.CalculatePrice(distance, carType);
            Console.WriteLine($"Khoảng cách: {distance:F2} km, Giá tiền: {price:F2}");

            // Chờ tài xế
            Console.WriteLine("Vui lòng chờ tài xế đến. Nhấn '1' để hủy chuyến...");
            bool tripCancelled = false;
            int waitTime = 15000;
            int elapsed = 0;
            while (elapsed < waitTime)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.KeyChar == '1')
                    {
                        tripCancelled = true;
                        Console.WriteLine("\nChuyến đi đã bị hủy.");
                        break;
                    }
                }
                Thread.Sleep(1000);
                elapsed += 1000;
                Console.WriteLine($"Đã chờ {elapsed / 1000} giây...");
            }

            if (!tripCancelled)
            {
                Console.WriteLine("Tài xế đã đến.");
                Trip trip = TripHandler.CreateTrip(currentCustomer, startLocation, endLocation, driver, distance, price);
                Console.WriteLine($"Chuyến đi {trip.Id} đã được tạo thành công.");
            }
        }
    }

    public class Check
    {
        public static double GetValidDoubleInput()
        {
            double value;
            while (!double.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Giá trị không hợp lệ. Nhập lại: ");
            }
            return value;
        }
    }
}