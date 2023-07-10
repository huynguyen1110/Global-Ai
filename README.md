<<<<<<< HEAD
# GlobalAI

## Tổng quan dự án
- BE: .net 6
- DB: Oracle 21c (innovation release)
- FE: Nuxt 3 (vue 3)

### Các tool nên dùng khi dev
#### SQL Developer
- Để thao tác với db oracle, hàng của oracle luôn, nhưng để lâu ko động vào thì hay bị treo.
#### Dbeaver
- Để thao tác với db oracle, nhanh nhẹ.
#### Visual Studio 2022 Community
- Để dev be. Bản community nào cũng được nhưng cài 2022 cho ngon
#### Visual Studio Code 
- Để Code fe. 
- Nên cài extension Tailwind CSS IntelliSense để được hỗ trợ làm việc với tailwind class
- Nên cài extension vscode-icons để icon bên Folder worskpace trông đẹp hơn
- Nên cài extension Vetur để hỗ trợ vue
- Nên cài extension Auto Rename Tag để đổi tên thẻ tiện hơn
#### Vue.js devtools
- Là extension trên chrome.
- Có thể cài để dev vue tiện hơn. 
- Giống giống kiểu f12 rồi vào tab style nhưng đây là phục vụ riêng cho vue.
#### Postman
- Để call api, nếu ko thích dùng Swagger
#### Git
- Để thao tác vs source code

## BACK END
### Kiến trúc microservices
https://www.google.com/search?q=microservices&client=opera&bih=980&biw=1880&hl=vi&ei=T1keZN34MuWSseMPsqKMgA0&ved=0ahUKEwid3Kmygfb9AhVlSWwGHTIRA9AQ4dUDCA4&uact=5&oq=microservices&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAzIHCAAQigUQQzIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDoKCAAQRxDWBBCwAzoLCAAQgAQQsQMQgwE6CAguEIAEELEDOggIABCABBCxAzoRCC4QgAQQsQMQgwEQxwEQ0QM6CwguEIAEELEDEIMBOgoIABCKBRCxAxBDOgcIABANEIAESgQIQRgAUNkIWIwsYLIuaANwAXgAgAFgiAGNBpIBAjEwmAEAoAEByAEIwAEB&sclient=gws-wiz-serp
### Sử dụng package Ocelot làm API Gateway
- API Gateway trông như này: https://assets.website-files.com/5ff66329429d880392f6cba2/6178d93647ddf9f443e800f4_API%20Gateway%20example.png
- Hiểu đơn giản thì micro services sẽ có nhiều resource api khác nhau và gateway là cái gom các resource api đó lại thành một lối vào duy nhất.
VD có 2 resource api phục vụ cho 2 module trong dự án là product (sản phẩm) và payment (thanh toán). Ở phía client (mobile, web frontent) khi muốn gọi api tới 2 resource này, sẽ phải gọi api qua 2 domain (https://product.example.com/api và https://payment.exapmle.com/api). 
Thay vì vậy, phía BE sẽ sử dụng API Gateway để gom 2 resource api này thành 1 (https://gateway.example.com/api), khi nào client gọi api thì chỉ cần gọi duy nhất qua 1 domain này. Sau đó request sẽ được API Gatewat chia cho 2 resource api kia.
Sử dụng API Gateway thì phía BE sẽ dễ quản lý và dễ scale (mở rộng) hơn.
- Tìm hiểu thêm về API Gateway: https://www.google.com/search?q=api+gateway+in+microservices&client=opera&hs=Yhc&bih=980&biw=1880&hl=vi&ei=tFUeZJGcB_qOseMP_ey3qAI&oq=api+gateway+in+&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAxgAMgUIABCABDIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjoECAAQRzoKCAAQRxDWBBCwAzoKCAAQigUQsAMQQzoHCAAQigUQQzoNCC4QigUQxwEQ0QMQQzoLCAAQgAQQsQMQgwE6DQgAEIoFELEDEIMBEEM6CwguEIAEELEDEIMBOgcIABCABBATOggIABAWEB4QE0oECEEYAFC-B1ifI2DEMmgCcAN4AIABWogBlgmSAQIxNpgBAKABAcgBCsABAQ&sclient=gws-wiz-serp
- Về ocelot:
https://www.google.com/search?q=net+6+ocelot&client=opera&hs=3ed&ei=HWQeZNaSJv_RseMP2KO6uAE&ved=0ahUKEwiWlZTZi_b9AhX_aGwGHdiRDhcQ4dUDCA4&uact=5&oq=net+6+ocelot&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAzIECAAQHjIECAAQHjIECAAQHjIGCAAQCBAeMgYIABAIEB4yBggAEAgQHjIGCAAQCBAeMgYIABAIEB4yBggAEAgQHjIGCAAQCBAeOgoIABBHENYEELADOgoIABCKBRCwAxBDOhIILhCKBRDUAhDIAxCwAxBDGAE6DwguEIoFEMgDELADEEMYAToGCAAQBxAeOggIABAIEAcQHkoECEEYAFCwC1jwE2DyFGgBcAF4AIABdogB_ASSAQMyLjSYAQCgAQHIAQ_AAQHaAQYIARABGAg&sclient=gws-wiz-serp
### Sử dụng package OpenidDict để xác thực
https://github.com/openiddict/openiddict-core
- Hiểu đơn giản dự án bao gồm các resource api và 1 authorize server (identity server). Authorize server có chức năng cấp access token, refresh token, xác thực người dùng.
- Mỗi lần user login, Authorize server sẽ cấp cho họ access token (jwt). Sau khi nhận được token, client khi gửi request sẽ kèm theo cả token ở Header để Authorize server xác thực.
- Nên đọc thêm về OAuth2 và OpenId, cấu trúc của jwt để hiểu sâu hơn
### Sử dụng kiến trúc 3 lớp trong mỗi service (project)
- https://www.codeproject.com/Articles/36847/Three-Layer-Architecture-in-C-NET-2
#### Hiểu đơn giản thì project (project trong solution) sẽ được chia thành 3 lớp.
- Lớp 1 là API controller (Presetation layer), lớp này là lớp đầu tiên mà request đi vào. 
- Lớp thứ 2 là Domain layer (Business layer), lớp này chứa các hàm xử lý logic nghiệp vụ. Lớp này sẽ sử dụng các hàm của lớp 3 để xử lý nghiệp vụ
Vd như cập nhật 2 bảng Product và ProductDetail khi thêm sản phẩm,...
- Lớp thứ 3 là Data Layer, lớp này chứa các hàm thao tác với dữ liệu trong db. Vd như thêm 1 bản ghi, xóa dữ liệu, update bản ghi, lấy dữ liệu,...
#### Trong code
- Lớp 1 sẽ nằm ở project có tên <tên project>API. Chứa các API Controller. Mỗi api trong đây sẽ gọi các service cần thiết để thực thi yêu cầu từ request.
- Lớp 2 sẽ nằm ở project có tên <tên project>Domain. Chứa 2 folder Interfaces và Implements. Mỗi một file trong interface gọi là 1 service.
Lưu ý là service này và service trong microservice khác nhau.
- Lớp 3 sẽ nằm ở project có tên <tên project>Repositories. Chứa các repository. Mỗi file repository tương ứng với 1 entity.

### Sử dụng DI (Dependency Injection)
https://www.google.com/search?client=opera&q=c%23+dependency+injection&sourceid=opera&ie=UTF-8&oe=UTF-8
- Hiểu đơn giản là khi viết code thì kiểu gì cũng phải chỉnh sửa code. Sử dụng DI sẽ dễ sửa code hơn, sửa ít chỗ hơn vì class bố chỉ cần khai bảo interface của class con chứ ko cần khai báo trực tiếp class con.
- Đọc lại về constructor
#### AddScope, AddTransient, AddSingleton
https://www.google.com/search?client=opera&hs=Rly&q=c%23+net+6+add+scope+and+singleton+addtransient&spell=1&sa=X&ved=2ahUKEwiys935kfb9AhWgSWwGHaRLCRcQBSgAegQIJxAB&biw=1880&bih=980&dpr=1
- Sử dụng DI trong net 6 thì cần biết cách phân biệt và sử dụng 3 cái này
- Hiểu đơn giản khi run project (phía dưới), app sẽ được khởi chạy. 
    - Khi app khởi chạy, nếu 1 class được AddSingleton, nó sẽ chỉ khởi tạo 1 lần lúc đó và chạy đến khi tắt app. Tức là mỗi request gửi tới be, thì sẽ đều sử dụng instance được tạo lúc app mới chạy luôn. 
    - Nếu 1 class được Add Transient, cho dù là trong cùng 1 request, nếu 1 class được khởi tạo nhiều hơn 1 lần, thì sẽ có nhiều instance của class đó được sinh ra. Khác nhau hoàn toàn luôn.
    - Nếu 1 class được Add Scope, thì trong cùng 1 request, nếu 1 class được khởi tạo nhiều hơn 1 lần, cũng vẫn chỉ có 1 instance được sinh ra. Request tiếp theo gửi tới thì app sẽ sinh instance khác cho request đó.
- Đọc thêm: https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences

### Run project khi dev
#### BE
- Vào src/GlobalAI, ấn GlobalAI.sln
#### Bật swagger
- Run ở chế độ multi project (mỗi project tương ứng 1 service)
https://davecallan.com/running-multiple-projects-visual-studio/
- Vào địa chỉ http://localhost:5003/swagger/index.html


### Comment code
1. Tổng quan
    - comment càng chi tiết càng tốt
    - các method giải thích đầu vào đầu ra, logic phức tạp
2. Repositories
    - comment tại tất cả các method trong repo giải thích đầu vào đầu ra xử lý bên trong nếu join nhiều bảng

### Coding convetion C#
1. Tổng quan
    - Tuân theo convetion **PascalCase** tức viết hoa chữ cái đầu tiên
    - Các biến sẽ viết theo convetion **CamelCase** viết thường chữ cái đầu
2. Dtos
    - Đặt tên Dto nếu là model tương tự với Entity (_các trường dữ liệu giống hệt_) thì đặt tên theo dạng `EntityDto` nếu là một class mở rộng thêm các trường thì đặt tên theo dạng `EntityWith` `GiDo` `Dto`
    - Không dùng chung 1 class Dto ở 2 hàm mà không cùng trả ra các trường giống nhau 
    - Các class Dto thêm mới từ giờ không thêm tiếp vào project `EPIC.Entities` mà phải để ở các project `Entities` của chính microservice đó, tương lại các Dto đặt không đúng microservice sẽ phải được chuyển về đúng chỗ.
3. Services
    - Viết trong project Domain của từng _microservice_
4. Repositories
    - Các method `GetById` thực sự chỉ đơn giản là `GetById` không xử lý thêm các trường bên ngoài entity nếu có đặt tên hàm khác, không `throw Exception` tại các method `GetById` nếu không tìm thấy chỉ trả ra `null`
    - Mỗi một bảng 1 repository trường hợp đã xử lý nhiều bảng theo nghiệp vụ thì comment summary trên class repository là tương tác đến những bảng nào theo dạng `<summary>` `Xử lý bảng:` `EP_ABC, EP_DEF` `</summary>`
5. Cách viết log
    - log information cho các tham số truyền vào trong hàm dạng như sau:
    ```cs
        public PagingResult<ResultDto> MethodName(InputDto input, int? idOrther = null)
        {
            _logger.LogInformation($"{nameof(MethodName)}: input = {JsonSerializer.Serialize(input)}, idOrther = {idOrther}");
        }
    ```
6. Cách mô tả swagger
    - Chèn thêm attribute `ProducesResponseType` theo mẫu như bên dưới
    - Thêm các comment summery vào các trường trong class Dto trả ra
    ```cs
        [HttpGet("find")]
        [ProducesResponseType(typeof(APIResponse<List<AppGarnerDistributionDto>>), (int)HttpStatusCode.OK)]
        public APIResponse AppDistributionGetAll(string keyword) 
        {
            //nội dung api
        }
    ```
    - Config swagger như sau để sinh comment trên swagger
    ```cs
        // Set the comments path for the Swagger JSON and UI.**
        option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"EPIC.GarnerEntities.xml"));
    ```
7. SignalR
    - test hub: https://gourav-d.github.io/SignalR-Web-Client/dist/
### Coding convetion DB
1. Tổng quan
    - Đặt tên các bảng theo đúng ý nghĩa và liên quan đến mảng nghiệp vụ nào
2. Error Code
    - Số mã lỗi đặt tương ứng với nghiệp vụ đang xử lý vd: bond 3xxx không đặt nhảy cách số phải liên tiếp. các mã lỗi nếu cần xử lý trong C# thì viết tiếp vào class ErrorCodes theo đúng thứ tự tăng dần không đặt linh tinh.
3. Migrations
    - Sinh migrations trong project HostConsole
    ```
        dotnet ef migrations add <MigrationName>
    ```
    - Apply migrations vừa tạo vào database
    ```
        dotnet ef database update
    ```
    - Lỗi OracleException: ORA-01950: no privileges on tablespace 'USERS' -> gõ lệnh sau vào script trong db:
        GRANT UNLIMITED TABLESPACE TO <Schema Name>;

### Tìm code
1. regex
    `_logger\.LogError\(.+\,\s{0,1}\$.+\;`
    
## FRONT END
### Tổng quan (Tới ngày 03/04/23)
- Sử dụng framework Nuxtjs 3 (SSR)
    - https://nuxt.com
    - https://vuejs.org
- CSS Framework: Sử dụng tailwind 
    - https://tailwindcss.com
- Validate form: Sử dụng vee-validate
    - https://vee-validate.logaretm.com/v4/guide/overview/
- Icon: Sử dụng font-awesome
    - 
## Commit
1. Tổng quan
    - Tách riêng các commit fix bug và commit tính năng mới
    - Nếu cần `pull` code mới về thì sử dụng lệnh `git stash` để cất code đi sau khi pull code từ _branch develop_ về thì dùng lệnh `git stash apply` để đưa code đang làm dở ra lại không mỗi lần `pull code` lại `commit` một lần tạo rất nhiều `commit` thừa
        - Với lệnh `git stash apply` code thể dùng trong giao diện của visual studio
        - Với trường hợp cần bỏ code đã cất đi dùng lênh `git stash drop` lưu ý cẩn thận khi dùng lệnh này sẽ xoá code đã cất đi _**Không thể khôi phục**_
    - Không tự ý merge code phải tạo `merge request` để check lại
    - `message commit` viết có ý nghĩa theo convetion sau:
        - Bug: `[Bug] nguồn bug từ đâu - nội dung bug được fix`
        - Tính năng mới: `Mô tả tính năng`
=======
# GlobalAI

## Tổng quan dự án
- BE: .net 6
- DB: Oracle 21c (innovation release)
- FE: Nuxt 3 (vue 3)

### Các tool nên dùng khi dev
#### SQL Developer
- Để thao tác với db oracle, hàng của oracle luôn, nhưng để lâu ko động vào thì hay bị treo.
#### Dbeaver
- Để thao tác với db oracle, nhanh nhẹ.
#### Visual Studio 2022 Community
- Để dev be. Bản community nào cũng được nhưng cài 2022 cho ngon
#### Visual Studio Code 
- Để Code fe. 
- Nên cài extension Tailwind CSS IntelliSense để được hỗ trợ làm việc với tailwind class
- Nên cài extension vscode-icons để icon bên Folder worskpace trông đẹp hơn
- Nên cài extension Vetur để hỗ trợ vue
- Nên cài extension Auto Rename Tag để đổi tên thẻ tiện hơn
#### Vue.js devtools
- Là extension trên chrome.
- Có thể cài để dev vue tiện hơn. 
- Giống giống kiểu f12 rồi vào tab style nhưng đây là phục vụ riêng cho vue.
#### Postman
- Để call api, nếu ko thích dùng Swagger
#### Git
- Để thao tác vs source code

## BACK END
### Kiến trúc microservices
https://www.google.com/search?q=microservices&client=opera&bih=980&biw=1880&hl=vi&ei=T1keZN34MuWSseMPsqKMgA0&ved=0ahUKEwid3Kmygfb9AhVlSWwGHTIRA9AQ4dUDCA4&uact=5&oq=microservices&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAzIHCAAQigUQQzIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDIFCAAQgAQyBQgAEIAEMgUIABCABDoKCAAQRxDWBBCwAzoLCAAQgAQQsQMQgwE6CAguEIAEELEDOggIABCABBCxAzoRCC4QgAQQsQMQgwEQxwEQ0QM6CwguEIAEELEDEIMBOgoIABCKBRCxAxBDOgcIABANEIAESgQIQRgAUNkIWIwsYLIuaANwAXgAgAFgiAGNBpIBAjEwmAEAoAEByAEIwAEB&sclient=gws-wiz-serp
### Sử dụng package Ocelot làm API Gateway
- API Gateway trông như này: https://assets.website-files.com/5ff66329429d880392f6cba2/6178d93647ddf9f443e800f4_API%20Gateway%20example.png
- Hiểu đơn giản thì micro services sẽ có nhiều resource api khác nhau và gateway là cái gom các resource api đó lại thành một lối vào duy nhất.
VD có 2 resource api phục vụ cho 2 module trong dự án là product (sản phẩm) và payment (thanh toán). Ở phía client (mobile, web frontent) khi muốn gọi api tới 2 resource này, sẽ phải gọi api qua 2 domain (https://product.example.com/api và https://payment.exapmle.com/api). 
Thay vì vậy, phía BE sẽ sử dụng API Gateway để gom 2 resource api này thành 1 (https://gateway.example.com/api), khi nào client gọi api thì chỉ cần gọi duy nhất qua 1 domain này. Sau đó request sẽ được API Gatewat chia cho 2 resource api kia.
Sử dụng API Gateway thì phía BE sẽ dễ quản lý và dễ scale (mở rộng) hơn.
- Tìm hiểu thêm về API Gateway: https://www.google.com/search?q=api+gateway+in+microservices&client=opera&hs=Yhc&bih=980&biw=1880&hl=vi&ei=tFUeZJGcB_qOseMP_ey3qAI&oq=api+gateway+in+&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAxgAMgUIABCABDIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjIGCAAQFhAeMgYIABAWEB4yBggAEBYQHjoECAAQRzoKCAAQRxDWBBCwAzoKCAAQigUQsAMQQzoHCAAQigUQQzoNCC4QigUQxwEQ0QMQQzoLCAAQgAQQsQMQgwE6DQgAEIoFELEDEIMBEEM6CwguEIAEELEDEIMBOgcIABCABBATOggIABAWEB4QE0oECEEYAFC-B1ifI2DEMmgCcAN4AIABWogBlgmSAQIxNpgBAKABAcgBCsABAQ&sclient=gws-wiz-serp
- Về ocelot:
https://www.google.com/search?q=net+6+ocelot&client=opera&hs=3ed&ei=HWQeZNaSJv_RseMP2KO6uAE&ved=0ahUKEwiWlZTZi_b9AhX_aGwGHdiRDhcQ4dUDCA4&uact=5&oq=net+6+ocelot&gs_lcp=Cgxnd3Mtd2l6LXNlcnAQAzIECAAQHjIECAAQHjIECAAQHjIGCAAQCBAeMgYIABAIEB4yBggAEAgQHjIGCAAQCBAeMgYIABAIEB4yBggAEAgQHjIGCAAQCBAeOgoIABBHENYEELADOgoIABCKBRCwAxBDOhIILhCKBRDUAhDIAxCwAxBDGAE6DwguEIoFEMgDELADEEMYAToGCAAQBxAeOggIABAIEAcQHkoECEEYAFCwC1jwE2DyFGgBcAF4AIABdogB_ASSAQMyLjSYAQCgAQHIAQ_AAQHaAQYIARABGAg&sclient=gws-wiz-serp
### Sử dụng package OpenidDict để xác thực
https://github.com/openiddict/openiddict-core
- Hiểu đơn giản dự án bao gồm các resource api và 1 authorize server (identity server). Authorize server có chức năng cấp access token, refresh token, xác thực người dùng.
- Mỗi lần user login, Authorize server sẽ cấp cho họ access token (jwt). Sau khi nhận được token, client khi gửi request sẽ kèm theo cả token ở Header để Authorize server xác thực.
- Nên đọc thêm về OAuth2 và OpenId, cấu trúc của jwt để hiểu sâu hơn
### Sử dụng kiến trúc 3 lớp trong mỗi service (project)
- https://www.codeproject.com/Articles/36847/Three-Layer-Architecture-in-C-NET-2
#### Hiểu đơn giản thì project (project trong solution) sẽ được chia thành 3 lớp.
- Lớp 1 là API controller (Presetation layer), lớp này là lớp đầu tiên mà request đi vào. 
- Lớp thứ 2 là Domain layer (Business layer), lớp này chứa các hàm xử lý logic nghiệp vụ. Lớp này sẽ sử dụng các hàm của lớp 3 để xử lý nghiệp vụ
Vd như cập nhật 2 bảng Product và ProductDetail khi thêm sản phẩm,...
- Lớp thứ 3 là Data Layer, lớp này chứa các hàm thao tác với dữ liệu trong db. Vd như thêm 1 bản ghi, xóa dữ liệu, update bản ghi, lấy dữ liệu,...
#### Trong code
- Lớp 1 sẽ nằm ở project có tên <tên project>API. Chứa các API Controller. Mỗi api trong đây sẽ gọi các service cần thiết để thực thi yêu cầu từ request.
- Lớp 2 sẽ nằm ở project có tên <tên project>Domain. Chứa 2 folder Interfaces và Implements. Mỗi một file trong interface gọi là 1 service.
Lưu ý là service này và service trong microservice khác nhau.
- Lớp 3 sẽ nằm ở project có tên <tên project>Repositories. Chứa các repository. Mỗi file repository tương ứng với 1 entity.

### Sử dụng DI (Dependency Injection)
https://www.google.com/search?client=opera&q=c%23+dependency+injection&sourceid=opera&ie=UTF-8&oe=UTF-8
- Hiểu đơn giản là khi viết code thì kiểu gì cũng phải chỉnh sửa code. Sử dụng DI sẽ dễ sửa code hơn, sửa ít chỗ hơn vì class bố chỉ cần khai bảo interface của class con chứ ko cần khai báo trực tiếp class con.
- Đọc lại về constructor
#### AddScope, AddTransient, AddSingleton
https://www.google.com/search?client=opera&hs=Rly&q=c%23+net+6+add+scope+and+singleton+addtransient&spell=1&sa=X&ved=2ahUKEwiys935kfb9AhWgSWwGHaRLCRcQBSgAegQIJxAB&biw=1880&bih=980&dpr=1
- Sử dụng DI trong net 6 thì cần biết cách phân biệt và sử dụng 3 cái này
- Hiểu đơn giản khi run project (phía dưới), app sẽ được khởi chạy. 
    - Khi app khởi chạy, nếu 1 class được AddSingleton, nó sẽ chỉ khởi tạo 1 lần lúc đó và chạy đến khi tắt app. Tức là mỗi request gửi tới be, thì sẽ đều sử dụng instance được tạo lúc app mới chạy luôn. 
    - Nếu 1 class được Add Transient, cho dù là trong cùng 1 request, nếu 1 class được khởi tạo nhiều hơn 1 lần, thì sẽ có nhiều instance của class đó được sinh ra. Khác nhau hoàn toàn luôn.
    - Nếu 1 class được Add Scope, thì trong cùng 1 request, nếu 1 class được khởi tạo nhiều hơn 1 lần, cũng vẫn chỉ có 1 instance được sinh ra. Request tiếp theo gửi tới thì app sẽ sinh instance khác cho request đó.
- Đọc thêm: https://stackoverflow.com/questions/38138100/addtransient-addscoped-and-addsingleton-services-differences

### Run project khi dev
#### BE
- Vào src/GlobalAI, ấn GlobalAI.sln
#### Bật swagger
- Run ở chế độ multi project (mỗi project tương ứng 1 service)
https://davecallan.com/running-multiple-projects-visual-studio/
- Vào địa chỉ http://localhost:5003/swagger/index.html


### Comment code
1. Tổng quan
    - comment càng chi tiết càng tốt
    - các method giải thích đầu vào đầu ra, logic phức tạp
2. Repositories
    - comment tại tất cả các method trong repo giải thích đầu vào đầu ra xử lý bên trong nếu join nhiều bảng

### Coding convetion C#
1. Tổng quan
    - Tuân theo convetion **PascalCase** tức viết hoa chữ cái đầu tiên
    - Các biến sẽ viết theo convetion **CamelCase** viết thường chữ cái đầu
2. Dtos
    - Đặt tên Dto nếu là model tương tự với Entity (_các trường dữ liệu giống hệt_) thì đặt tên theo dạng `EntityDto` nếu là một class mở rộng thêm các trường thì đặt tên theo dạng `EntityWith` `GiDo` `Dto`
    - Không dùng chung 1 class Dto ở 2 hàm mà không cùng trả ra các trường giống nhau 
    - Các class Dto thêm mới từ giờ không thêm tiếp vào project `EPIC.Entities` mà phải để ở các project `Entities` của chính microservice đó, tương lại các Dto đặt không đúng microservice sẽ phải được chuyển về đúng chỗ.
3. Services
    - Viết trong project Domain của từng _microservice_
4. Repositories
    - Các method `GetById` thực sự chỉ đơn giản là `GetById` không xử lý thêm các trường bên ngoài entity nếu có đặt tên hàm khác, không `throw Exception` tại các method `GetById` nếu không tìm thấy chỉ trả ra `null`
    - Mỗi một bảng 1 repository trường hợp đã xử lý nhiều bảng theo nghiệp vụ thì comment summary trên class repository là tương tác đến những bảng nào theo dạng `<summary>` `Xử lý bảng:` `EP_ABC, EP_DEF` `</summary>`
5. Cách viết log
    - log information cho các tham số truyền vào trong hàm dạng như sau:
    ```cs
        public PagingResult<ResultDto> MethodName(InputDto input, int? idOrther = null)
        {
            _logger.LogInformation($"{nameof(MethodName)}: input = {JsonSerializer.Serialize(input)}, idOrther = {idOrther}");
        }
    ```
6. Cách mô tả swagger
    - Chèn thêm attribute `ProducesResponseType` theo mẫu như bên dưới
    - Thêm các comment summery vào các trường trong class Dto trả ra
    ```cs
        [HttpGet("find")]
        [ProducesResponseType(typeof(APIResponse<List<AppGarnerDistributionDto>>), (int)HttpStatusCode.OK)]
        public APIResponse AppDistributionGetAll(string keyword) 
        {
            //nội dung api
        }
    ```
    - Config swagger như sau để sinh comment trên swagger
    ```cs
        // Set the comments path for the Swagger JSON and UI.**
        option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
        option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"EPIC.GarnerEntities.xml"));
    ```
7. SignalR
    - test hub: https://gourav-d.github.io/SignalR-Web-Client/dist/
### Coding convetion DB
1. Tổng quan
    - Đặt tên các bảng theo đúng ý nghĩa và liên quan đến mảng nghiệp vụ nào
2. Error Code
    - Số mã lỗi đặt tương ứng với nghiệp vụ đang xử lý vd: bond 3xxx không đặt nhảy cách số phải liên tiếp. các mã lỗi nếu cần xử lý trong C# thì viết tiếp vào class ErrorCodes theo đúng thứ tự tăng dần không đặt linh tinh.
3. Migrations
    - Sinh migrations trong project HostConsole
    ```
        dotnet ef migrations add <MigrationName>
    ```
    - Apply migrations vừa tạo vào database
    ```
        dotnet ef database update
    ```
    - Lỗi OracleException: ORA-01950: no privileges on tablespace 'USERS' -> gõ lệnh sau vào script trong db:
        GRANT UNLIMITED TABLESPACE TO <Schema Name>;

### Tìm code
1. regex
    `_logger\.LogError\(.+\,\s{0,1}\$.+\;`
    
## FRONT END
### Tổng quan (Tới ngày 03/04/23)
- Sử dụng framework Nuxtjs 3 (SSR)
    - https://nuxt.com
    - https://vuejs.org
- CSS Framework: Sử dụng tailwind 
    - https://tailwindcss.com
- Validate form: Sử dụng vee-validate
    - https://vee-validate.logaretm.com/v4/guide/overview/
- Icon: Sử dụng font-awesome
    - 
## Commit
1. Tổng quan
    - Tách riêng các commit fix bug và commit tính năng mới
    - Nếu cần `pull` code mới về thì sử dụng lệnh `git stash` để cất code đi sau khi pull code từ _branch develop_ về thì dùng lệnh `git stash apply` để đưa code đang làm dở ra lại không mỗi lần `pull code` lại `commit` một lần tạo rất nhiều `commit` thừa
        - Với lệnh `git stash apply` code thể dùng trong giao diện của visual studio
        - Với trường hợp cần bỏ code đã cất đi dùng lênh `git stash drop` lưu ý cẩn thận khi dùng lệnh này sẽ xoá code đã cất đi _**Không thể khôi phục**_
    - Không tự ý merge code phải tạo `merge request` để check lại
    - `message commit` viết có ý nghĩa theo convetion sau:
        - Bug: `[Bug] nguồn bug từ đâu - nội dung bug được fix`
        - Tính năng mới: `Mô tả tính năng`
>>>>>>> f3524a4de69a52b02df32418a0812ac5137fab10
