----------Banner table data-----------

INSERT INTO Banners (BannerId, Link, IsActive, PromoCode, Locations, ImagePath)
VALUES
('10577501-aaef-47c8-4336-08dc7e418ce1', 'www.bannerlink1.com', 1, 'Normal Flag', 'Pune', 'https://images.pexels.com/photos/573130/pexels-photo-573130.jpeg?cs=srgb&dl=pexels-zyuliansyah-573130.jpg&fm=jpg'),
('07f4a038-b6cf-40c2-ed22-08dc7e48da15', 'www.bannerlink2.com', 1, 'Normal Flag', 'Mahabaleshwar', 'https://indiater.com/wp-content/uploads/2019/03/mahabaleshwar-tour-packages-social-media-banners.jpg'),
('4c8e009f-a6b9-4180-fe72-08dc7e4dc2ea', 'www.Bannerslink3.com', 1, 'QWERTYUIO', 'Delhi', 'https://letsenhance.io/static/8f5e523ee6b2479e26ecc91b9c25261e/1015f/MainAfter.jpg'),
('2e7dc255-8fe8-4f6e-4d40-08dc7ed9c50a', 'www.bannerlin.com', 1, 'qwertyui', 'Nagpur', 'https://c8.alamy.com/comp/HPNEYD/nagpur-red-text-on-typography-background-3d-rendered-royalty-free-HPNEYD.jpg');


------------User Table---------------

 INSERT INTO [AspNetUsers] (
    [Id], [Name], [CreatedBy], [CreatedDate], [LastModifiedBy], [LastModifiedDate]
)
VALUES
('a8a62a00-5379-467b-bbce-0dfa981fed52', 'Rope Climbing', NULL, '0001-01-01 00:00:00.0000000', NULL, NULL),
('6e55b2a4-6f6e-45a0-ac39-b5e8aeb497d1', 'Stargazing', NULL, '0001-01-01 00:00:00.0000000', NULL, NULL),
('f7f7dfbc-e168-4400-af24-d0fd03660b75', 'Hiking', NULL, '0001-01-01 00:00:00.0000000', NULL, NULL),
('9b74773c-adb2-4069-8547-f76c0a70bcc1', 'Swimming', NULL, '0001-01-01 00:00:00.0000000', NULL, NULL);

----------Contact Us-------------------

INSERT INTO [ContactUs] (