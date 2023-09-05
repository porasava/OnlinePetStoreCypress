//Cypress - Spec

describe('TC1AdminAddProductFailed', () => {
  it('TC1 Failed to add product', () => {
    cy.visit('http://192.168.3.111:8042/User/AdminLogin')
    cy.get('#AdminUsername').type('Tananya')
    cy.get('#AdminPassword').type("Tanya123")
    cy.get('[type="submit"]').click()
    cy.get('.navbar-collapse > :nth-child(1) > :nth-child(1) > a').click()
    cy.get('#CategoryId').select('        14').should('have.value','        14')
    cy.get('#ItemCode').type('Item Code')
    cy.get('#ItemName').type('Item Name')
    cy.get('#Description').type('Description')
    cy.get('#ItemPrice').type('20')
    cy.get('#btnSave').click()
    cy.on('window:alert',(str)=>
    {
      //Mocha
      expect(str).to.equal('There is some problem to add Item.')
    })
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})



describe('TC2AdminAddProductSuccess', () => {
  it('TC2 Admin Add Product Success', () => {
    cy.visit('http://192.168.3.111:8042/User/AdminLogin')
    cy.get('#AdminUsername').type('Tananya')
    cy.get('#AdminPassword').type("Tanya123")
    cy.get('[type="submit"]').click()
    cy.get('.navbar-collapse > :nth-child(1) > :nth-child(1) > a').click()
    cy.get('#CategoryId').select('        14').should('have.value','        14')
    cy.get('#ItemCode').type('Adidas 001')
    cy.get('#ItemName').type('Adidas')
    cy.get('#Description').type('Adidas 001')
    cy.get('#ItemPrice').type('200')
    cy.get('#ImagePath').selectFile(__dirname+'\\adidas_shoe.jfif')
    cy.get('#btnSave').click()
          cy.on('window:alert',(str)=>
    {
      //Mocha
      expect(str).to.equal('Item is added Successfully.')
    })
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})



describe('TC3AdminDeleteProductSuccess', () => {
  it('TC3 Admin Delete Product Success', () => {
    cy.visit('http://192.168.3.111:8042/User/AdminLogin')
    cy.get('#AdminUsername').type('Tananya')
    cy.get('#AdminPassword').type("Tanya123")
    cy.get('[type="submit"]').click()
    cy.get(':nth-child(2) > :nth-child(6) > a').click()
    cy.get('.btn').click()
    cy.get(`a[href="/Product"]`).click()
    cy.get("tbody tr:nth-child(2) td:nth-child(3)").check.toString("Bravecto")
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})




describe('TC4CutomerRegisterFailed', () => {
  it('TC4 Cutomer Register Failed', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('td > #loginlink').click()
    cy.get('#FirstName').type('TananyaTest')
    cy.get('#LastName').type('AsaTest')
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('1234')
    cy.get('#ConfirmPassword').type('12345')
    cy.get('#Email').type('AsaTest@hotmail.com')
    cy.get('[type="submit"]').click()
    cy.get('.btn').click()    
    cy.get('#ConfirmPassword-error').check.toString(`'Confirm Password' and 'Password' do not match.`)
    cy.viewport(1350, 700);
    cy.screenshot()
  })
})




describe('TC5CutomerRegisterSuccess', () => {
  it('TC5 Cutomer Register Success', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('td > #loginlink').click()
    cy.get('#FirstName').type('TananyaTest')
    cy.get('#LastName').type('AsaTest')
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('1234')
    cy.get('#ConfirmPassword').type('1234')
    cy.get('#Email').type('AsaTest@hotmail.com')
    cy.get('[type="submit"]').click()
    cy.get('.btn').click()    
    cy.get('.label-success').click.toString(`Registration successful.`)
    cy.viewport(1350, 700)
    cy.screenshot()
  })
})





describe('TC6CutomerLoginFailed', () => {
  it('TC6 Cutomer Login Failed', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('12345')
    cy.get('input[value="Login"]').click()
    cy.get('.field-validation-error').click.toString(`Wrong Username or Password`)
    cy.screenshot()
  })
})





describe('TC7CutomerLoginSuccess', () => {
  it('TC7 Cutomer Login Success', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('1234')
    cy.viewport(1350, 700);
    cy.get('input[value="Login"]').click()
    cy.get(".text-center").click.toString("Pet Product List")
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})





describe('TC8CutomerAddProductToCartSuccess', () => {
  it('TC8 Cutomer Add Product To Cart Success', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('1234')
    cy.get('input[value="Login"]').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > div:nth-child(5) > input:nth-child(1)').click()
    cy.viewport(1350, 700);
    cy.get("#cartItem").click.toString("Cart(1)")
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})





describe('TC9CutomerAddProductsToCartSuccess', () => {
  it('TC9 Cutomer Add Products To Cart Success', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('1234')
    cy.get('input[value="Login"]').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(3) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(4) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(4) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(5) > div:nth-child(5) > input:nth-child(1)').click()
    cy.viewport(1350, 700);
    cy.get("#cartItem").click.toString("Cart(4)")
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})




describe('TC10CheckCartPage', () => {
  it('TC10 Check Cart Page', () => {
    cy.visit('http://192.168.3.111:8042')
    cy.get('#loginlink').click()
    cy.get('#UserName').type('TananyaTest')
    cy.get('#Password').type('1234')
    cy.get('input[value="Login"]').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(2) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(3) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(4) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(5) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('body > div:nth-child(2) > div:nth-child(2) > div:nth-child(4) > div:nth-child(5) > input:nth-child(1)').click()
    cy.get('#cartItem').click()
    cy.get('[style="text-align: center"] > h3').contains('111.00 NZD')
    cy.viewport(1350, 700)
    cy.screenshot()
    cy.get('#logoutForm > a').click()
    })
  })





  describe('TC11CutomerLogoutSuccess', () => {
    it('TC11 Cutomer Logout Success', () => {
      cy.visit('http://192.168.3.111:8042')
      cy.get('#loginlink').click()
      cy.get('#UserName').type('TananyaTest')
      cy.get('#Password').type('1234')
      cy.get('input[value="Login"]').click()
      cy.get('#logoutForm > a').click()
      cy.get('div[class="container body-content"] h2').contains("Customer Login")
      cy.screenshot()
    })
})




describe('TC12AdminDeleteCustomerSuccess', () => {
  it('TC12 Admin Delete Customer Success', () => {
    cy.visit('http://192.168.3.111:8042/User/AdminLogin')
    cy.get('#AdminUsername').type('Tananya')
    cy.get('#AdminPassword').type("Tanya123")
    cy.get('[type="submit"]').click()
    cy.get(':nth-child(3) > a').click()
    cy.get(':nth-child(3) > :nth-child(6) > a').click()
    cy.get('.btn').click()   
    cy.get('div[class="container body-content"] h2').contains("Customer List")
    cy.screenshot()
    cy.get('#logoutForm > a').click()
  })
})






