using NetStore.Application.DTOs.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Application.Interfaces.Services.Marketplace
{
    public interface ITrendyolApiService
    {
        /// <summary>
        /// Trendyol’dan yeni siparişleri çek
        /// </summary>
        /// <param name="lastSyncDate">Son senkronizasyon tarihi, null ise tüm siparişleri getir</param>
        /// <returns>Trendyol siparişleri listesi</returns>
        Task<IEnumerable<TrendyolOrderDto>> GetOrdersAsync(DateTime? lastSyncDate = null);

        /// <summary>
        /// Ürün stok bilgisini Trendyol’a güncelle
        /// </summary>
        /// <param name="stockUpdate">Stok güncelleme bilgisi</param>
        /// <returns>Başarı durum bilgisi</returns>
        Task<bool> UpdateProductStockAsync(TrendyolProductStockUpdateDto stockUpdate);

        /// <summary>
        /// Yeni ürün bilgisi Trendyol’a gönder
        /// </summary>
        /// <param name="productDto">Gönderilecek ürün bilgileri</param>
        /// <returns>Başarı durum bilgisi</returns>
        Task<bool> SendProductAsync(TrendyolProductCreateDto productDto);

        /// <summary>
        /// Sipariş kargo bilgisini güncelle
        /// </summary>
        /// <param name="shipmentDto">Kargo bilgisi</param>
        /// <returns>Başarı durumu</returns>
        Task<bool> UpdateShipmentAsync(TrendyolShipmentUpdateDto shipmentDto);

        /// <summary>
        /// İade veya iptal işlemi bildir
        /// </summary>
        /// <param name="returnDto">İade / iptal bilgisi</param>
        /// <returns>Başarı durumu</returns>
        Task<bool> NotifyReturnAsync(TrendyolReturnRequestDto returnDto);
    }
}
