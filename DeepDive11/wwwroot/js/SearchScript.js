const productCardTemplate = document.querySelector('[data-product-template]'); //
const productCardsContainer = document.querySelector('[data-product-cards-container]');
const searchInput = document.querySelector('[data-search]');
const searchForm = document.querySelector('[data-search-form]');

let searchController;

function clearResults() {
    productCardsContainer.querySelectorAll('[data-search-result]').forEach(card => card.remove()); //Fjerner alle produkter fra containeren
    productCardsContainer.classList.remove('show');
}

function renderResults(products) { //Fjerner alle produkter fra containeren før nye resultater vises
    clearResults();

    if (products.length === 0) {
        return;
    }

    productCardsContainer.classList.add('show');

    products.forEach(product => { //Går igennem alle produkter og opretter et kort for hvert produkt
        const card = productCardTemplate.content.cloneNode(true).children[0]; //Kloner template og vælger første barn
        const header = card.querySelector('[data-header]'); //Vælger header elementet i kortet
        const body = card.querySelector('[data-body]'); //Vælger body elementet i kortet
        const image = card.querySelector('[data-image]'); //Vælger image elementet i kortet

        const link = document.createElement('a'); //Opretter et link element

        link.href = `/Products/Rent?id=${product.productId}`; //Sætter linket til at pege på produktet
        link.className = 'search-result-link'; //Sætter klassen til linket
        link.dataset.searchResult = '';
        header.textContent = product.model || product.brand; //Sætter header til model eller brand
        image.src = product.image ? `/images/${product.image}` : '/images/default.jpg'; //Sætter billedet til produktets billede
        body.textContent = [product.brand, product.type, product.category] //Sætter body til brand, type og kategori
            .filter(Boolean) //Filtrerer ud falsk værdier (null, undefined, tomme strenge)
            .join(' | '); //Sammenføjer de filtrerede værdier med en pipe

        link.append(card);
        productCardsContainer.append(link); //Tilføjer kortet til containeren
    });
}

async function searchProducts(query) { //Søger efter produkter baseret på søgeord
    searchController?.abort(); //Afbryder den forrige søgning, hvis den er i gang

    if (!query.trim()) { //Hvis søgeordet er tomt
        clearResults(); //Fjernes alle resultater
        return;
    }

    searchController = new AbortController();

    try { //Forsøger at hente produkter fra serveren baseret på søgeordet
        const response = await fetch(`/Products/Search?query=${encodeURIComponent(query)}`, { //Henter produkter fra serveren
            signal: searchController.signal //Bruger abort controlleren til at afbryde søgningen
        });

        if (!response.ok) {
            throw new Error(`Search request failed with status ${response.status}`); //Hvis en fejl sker , kastes en fejl med statuskoden
        }

        renderResults(await response.json());
    } catch (error) {
        if (error.name !== 'AbortError') {
            console.error('Unable to search products.', error);
        }
    }
}

searchInput.addEventListener('input', event => searchProducts(event.target.value));
searchForm.addEventListener('submit', event => event.preventDefault());