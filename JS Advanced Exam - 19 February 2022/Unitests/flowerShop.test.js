let flowerShop = require('./flowerShop.js');
let expect = require('chai').expect;

describe('floweShop', () => {
    describe('calcPriceOfFlower', () => {
        it('should throw error if flower isnt string', () => {
            expect(() => flowerShop.calcPriceOfFlowers(5,7,8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(7,8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers([],7,8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers({},7,8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(false,7,8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers(undefined,7,8)).to.throw(Error, 'Invalid input!');
        });
        it('should throw error if number isnt number', () => {
            expect(() => flowerShop.calcPriceOfFlowers('WoW','WoW',8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',[],0)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',{},-6)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',false,8)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',undefined,8)).to.throw(Error, 'Invalid input!');
            
            expect(() => flowerShop.calcPriceOfFlowers('WoW',8,'Emre')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',0)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',7,[])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',9,{})).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',10,false)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('WoW',12,undefined)).to.throw(Error, 'Invalid input!');
        });
        it('should work correctly', () => {
            let tofixed = (7*8).toFixed(2);
            let tofixed1 = (-7*8).toFixed(2);
            let tofixed2 = (0*8).toFixed(2);
            expect(flowerShop.calcPriceOfFlowers('rose',7,8)).to.be.equal(`You need $${tofixed} to buy rose!`);
            expect(flowerShop.calcPriceOfFlowers('roset',-7,8)).to.be.equal(`You need $${tofixed1} to buy roset!`);
            expect(flowerShop.calcPriceOfFlowers('Rose',0,8)).to.be.equal(`You need $${tofixed2} to buy Rose!`);
        });
    });
    describe('checkFlowersAvailable', () => {
        it('should return not avaible if flowe is smaller than 0', () => {
            expect(flowerShop.checkFlowersAvailable('Rose',['Flower','Emre','Viki'])).to.be.equal(`The Rose are sold! You need to purchase more!`)
            expect(flowerShop.checkFlowersAvailable('Rose',[])).to.be.equal(`The Rose are sold! You need to purchase more!`)
            expect(flowerShop.checkFlowersAvailable('flower',['Flower','Emre','Viki'])).to.be.equal(`The flower are sold! You need to purchase more!`)
        });
        it('shoulds work correctly', () => {
            expect(flowerShop.checkFlowersAvailable('Rose',['Flower','Emre','Viki','Rose'])).to.be.equal(`The Rose are available!`)
            expect(flowerShop.checkFlowersAvailable('Rose',['Rose'])).to.be.equal(`The Rose are available!`)
            expect(flowerShop.checkFlowersAvailable('R',['Flower','Emre','Viki','Rose', 'R'])).to.be.equal(`The R are available!`)
        });
    });
    describe('sellFlowers', () => {
        it('should throw error if array isnt integer and space isnt integer', () => {
            expect(() => flowerShop.sellFlowers('wow',['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(9,['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(-9,['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers({},['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(false,['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(undefined,['Rose','Lily'])).to.throw(Error, 'Invalid input!');

            expect(() => flowerShop.sellFlowers(['Rose','Lily'],'Emre')).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],[])).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],{})).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],false)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],undefined)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],-1)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],-50)).to.throw(Error, 'Invalid input!');

            expect(() => flowerShop.sellFlowers(['Rose','Lily'],50)).to.throw(Error, 'Invalid input!');
            expect(() => flowerShop.sellFlowers(['Rose','Lily'],2)).to.throw(Error, 'Invalid input!');
            
            
        });
        it('shouldss work correctly', () => {
            expect(flowerShop.sellFlowers(['Rose','Viki','WoW'],2)).to.be.equal('Rose / Viki');
            expect(flowerShop.sellFlowers(['Rose','Viki','WoW'],1)).to.be.equal('Rose / WoW');
            expect(flowerShop.sellFlowers(['Rose','Viki','WoW'],0)).to.be.equal('Viki / WoW');
        });
    });
});